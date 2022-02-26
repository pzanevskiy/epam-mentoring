using System;
using System.Windows.Forms;

namespace Fundametals.WinFroms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void helloButton_Click(object sender, EventArgs e)
        {
            var userName = inputTextBox.Text;
            MessageBox.Show($"Hello, {userName}!", $"Hello, {userName}!", MessageBoxButtons.OK);
        }
    }
}
