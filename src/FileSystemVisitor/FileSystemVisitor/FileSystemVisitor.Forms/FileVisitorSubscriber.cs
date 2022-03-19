using FileSystemVisitor.Lib.Arguments;
using FileSystemVisitor.Lib.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FileSystemVisitor.Forms
{
    class FileVisitorSubscriber : IEventSubscriber<IFileSystemVisitor>
    {
        private readonly DataGridView _eventsView;

        public FileVisitorSubscriber(DataGridView eventsView)
        {
            _eventsView = eventsView;
        }

        private void Publisher_FilteredDirectoryFound(object sender, FileInfoEventArgs e)
        {
            _eventsView?.Invoke(new Action(() =>
            {
                _eventsView.Rows.Add($"Filtered directory {e.FileInfoName} found!");
                _eventsView.Rows[_eventsView.Rows.GetLastRow(DataGridViewElementStates.Visible)]
                .DefaultCellStyle.BackColor = Color.Green;
            }));
        }

        private void Publisher_DirectoryFound(object sender, FileInfoEventArgs e)
        {
            _eventsView?.Invoke(new Action(() =>
            {
                _eventsView.Rows.Add($"Directory {e.FileInfoName} found!");
                _eventsView.Rows[_eventsView.Rows.GetLastRow(DataGridViewElementStates.Visible)]
                .DefaultCellStyle.BackColor = Color.Yellow;
            }));
        }

        private void Publisher_FilteredFileFound(object sender, FileInfoEventArgs e)
        {
            _eventsView?.Invoke(new Action(() =>
            {
                _eventsView.Rows.Add($"Filtered file {e.FileInfoName} found!");
                _eventsView.Rows[_eventsView.Rows.GetLastRow(DataGridViewElementStates.Visible)]
                .DefaultCellStyle.BackColor = Color.LightGreen;
            }));
        }

        private void Publisher_FileFound(object sender, FileInfoEventArgs e)
        {
            _eventsView?.Invoke(new Action(() =>
            {
                _eventsView.Rows.Add($"File {e.FileInfoName} found!");
                _eventsView.Rows[_eventsView.Rows.GetLastRow(DataGridViewElementStates.Visible)]
                .DefaultCellStyle.BackColor = Color.LightYellow;
            }));
        }

        private void Publisher_Finish(object sender, EventArgs e)
        {
            _eventsView?.Invoke(new Action(() =>
            {
                _eventsView.Rows.Add($"Finish!");
            }));
        }

        private void Publisher_Start(object sender, EventArgs e)
        {
            _eventsView?.Invoke(new Action(() =>
            {
                _eventsView.Rows.Add($"Start!");
            }));
        }

        public void Subscribe(IFileSystemVisitor publisher)
        {
            publisher.Start += Publisher_Start;
            publisher.Finish += Publisher_Finish;
            publisher.FileFound += Publisher_FileFound;
            publisher.FilteredFileFound += Publisher_FilteredFileFound;
            publisher.DirectoryFound += Publisher_DirectoryFound;
            publisher.FilteredDirectoryFound += Publisher_FilteredDirectoryFound;
        }

        public void Unubscribe(IFileSystemVisitor publisher)
        {
            publisher.Start -= Publisher_Start;
            publisher.Finish -= Publisher_Finish;
            publisher.FileFound -= Publisher_FileFound;
            publisher.FilteredFileFound -= Publisher_FilteredFileFound;
            publisher.DirectoryFound -= Publisher_DirectoryFound;
            publisher.FilteredDirectoryFound -= Publisher_FilteredDirectoryFound;
        }
    }
}
