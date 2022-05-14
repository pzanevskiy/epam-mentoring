using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.Core.Model;
using BrainstormSessions.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;
using Serilog.Sinks.Email;
using Serilog.Sinks.SystemConsole.Themes;

namespace BrainstormSessions
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(
                optionsBuilder => optionsBuilder.UseInMemoryDatabase("InMemoryDb"));

            services.AddControllersWithViews();

            services.AddScoped<IBrainstormSessionRepository,
                EFStormSessionRepository>();
            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddSerilog(dispose: true);
            });

            services.AddSingleton<ILoggerProvider, SerilogLoggerProvider>(sp =>
            {
                var serilogLogger = new LoggerConfiguration()
                    .Enrich.FromLogContext()
                    .WriteTo.Console(theme: AnsiConsoleTheme.Literate)
                    .WriteTo.Email(new EmailConnectionInfo()
                    {
                        FromEmail = "some email",
                        ToEmail = "some email",
                        MailServer = "smtp-mail.outlook.com",
                        EnableSsl = false,
                        Port = 587,
                        NetworkCredentials = new NetworkCredential()
                        {
                            UserName = "some email",
                            Password = "some password"
                        },
                        EmailSubject = "[{Timestamp:HH:mm:ss} {Level:u3}] Application Error"
                    },
                    batchPostingLimit: 10,
                    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error)
                    .CreateLogger();

                return new SerilogLoggerProvider(serilogLogger);
            });

        }

        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
            IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                var repository = serviceProvider.GetRequiredService<IBrainstormSessionRepository>();

                InitializeDatabaseAsync(repository).Wait();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public async Task InitializeDatabaseAsync(IBrainstormSessionRepository repo)
        {
            var sessionList = await repo.ListAsync();
            if (!sessionList.Any())
            {
                await repo.AddAsync(GetTestSession());
            }
        }

        public static BrainstormSession GetTestSession()
        {
            var session = new BrainstormSession()
            {
                Name = "Test Session 1",
                DateCreated = new DateTime(2016, 8, 1)
            };
            var idea = new Idea()
            {
                DateCreated = new DateTime(2016, 8, 1),
                Description = "Totally awesome idea",
                Name = "Awesome idea"
            };
            session.AddIdea(idea);
            return session;
        }
    }
}
