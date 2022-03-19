using FileSystemVisitor.Lib.Interfaces;
using FileSystemVisitor.Lib.Services;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSystemVisitor.Forms
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource _cts;
        //private Task _task;
        //private readonly IManagerService<ManagerEventArgs> _managerService;
        private IFileSystemVisitor _fileSystemVisitor;


        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            fileInfoGridView.Rows.Clear();
            try
            {
                var openFileDialog = new FolderBrowserDialog();
                _cts = new CancellationTokenSource();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _fileSystemVisitor = new FileSystemVisitorService(BuildFilter());
                    await Task.Run(async () =>
                    {
                        var files = _fileSystemVisitor.GetFileSystemInfo(openFileDialog.SelectedPath,
                            riseEventsCheckBox.Checked);
                        foreach (var item in files)
                        {
                            _cts.Token.ThrowIfCancellationRequested();
                            await Task.Delay(50);
                            fileInfoGridView.Invoke(new Action(() => fileInfoGridView.Rows.Add(item.Name, item.CreationTime)));
                        }
                    }, _cts.Token);
                }
            }
            catch (OperationCanceledException operationCanceledException)
            {
                MessageBox.Show(operationCanceledException.Message, "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            _cts.Cancel();
        }

        private Func<FileSystemInfo, bool> BuildFilter()
        {
            var filter = new Func<FileSystemInfo, bool>(c => c.CreationTime <= creationTimeFilter.Value);

            if (inclideDirs.Checked && !includeFiles.Checked)
            {
                filter += new Func<FileSystemInfo, bool>(x => x is DirectoryInfo);
            }
            if(includeFiles.Checked && !inclideDirs.Checked)
            {
                filter += new Func<FileSystemInfo, bool>(x => x is FileInfo);
            }
            if (!string.IsNullOrWhiteSpace(nameFilter.Text))
            {
                filter+= new Func<FileSystemInfo, bool>(x => x.Name.Contains(nameFilter.Text, 
                    StringComparison.OrdinalIgnoreCase));
            }

            return filter;
        }
    }
}
