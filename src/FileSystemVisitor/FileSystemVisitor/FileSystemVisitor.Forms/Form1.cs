using FileSystemVisitor.Console;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSystemVisitor.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var source = new BindingSource();
                var openFileDialog = new FolderBrowserDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var x = new FileSystemVisitorService();

                    var files = x.GetFileSystemInfo(openFileDialog.SelectedPath);
                    var filtered = files
                        .Where(x=>x is DirectoryInfo)
                        .Select(x => new { x.Name, x.LastWriteTime });
                    source.DataSource = filtered;
                    dataGridView1.DataSource = source;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }

        }
    }
}
