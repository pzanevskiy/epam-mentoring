using FileSystemVisitor.Lib.Interfaces;
using FileSystemVisitor.Lib.Services;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSystemVisitor.Forms
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource _cts;
        private IFileSystemVisitor _fileSystemVisitor;
        private readonly FileVisitorSubscriber _fileVisitorSubscriber;

        public Form1()
        {
            InitializeComponent();
            _fileVisitorSubscriber = new FileVisitorSubscriber(eventView);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            fileInfoGridView.Rows.Clear();
            eventView.Rows.Clear();
            try
            {
                var openFileDialog = new FolderBrowserDialog();
                _cts = new CancellationTokenSource();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _fileSystemVisitor = new FileSystemVisitorService(BuildFilter());
                    await Task.Run(async () =>
                    {
                        _fileVisitorSubscriber.Subscribe(_fileSystemVisitor);
                        var files = _fileSystemVisitor.GetFileSystemInfo(openFileDialog.SelectedPath,
                            riseEventsCheckBox.Checked);
                        foreach (var item in files)
                        {
                            _cts.Token.ThrowIfCancellationRequested();
                            await Task.Delay(50); // for testing purposes only
                            fileInfoGridView.Invoke(new Action(() => fileInfoGridView.Rows.Add(item.Name, item.CreationTime)));
                        }
                        _fileVisitorSubscriber.Unubscribe(_fileSystemVisitor);
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

        private void button2_Click(object sender, EventArgs e)
        {
            _cts.Cancel();
            _fileVisitorSubscriber.Unubscribe(_fileSystemVisitor);
        }

        private Func<FileSystemInfo, bool> BuildFilter()
        {
            Func<FileSystemInfo, bool> filter = null;

            if (inclideDirs.Checked && !includeFiles.Checked)
            {
                filter += new Func<FileSystemInfo, bool>(x => x is DirectoryInfo);
            }
            if (includeFiles.Checked && !inclideDirs.Checked)
            {
                filter += new Func<FileSystemInfo, bool>(x => x is FileInfo);
            }
            if (!string.IsNullOrWhiteSpace(nameFilter.Text))
            {
                filter += new Func<FileSystemInfo, bool>(x => x.Name.Contains(nameFilter.Text,
                     StringComparison.OrdinalIgnoreCase));
            }
            if (includeDate.Checked)
            {
                filter += new Func<FileSystemInfo, bool>(x => x.CreationTime < creationTimeFilter.Value);
            }

            return filter;
        }
    }
}
