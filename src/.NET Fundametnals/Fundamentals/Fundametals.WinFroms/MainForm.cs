using System;
using System.Windows.Forms;
using Fundamentals.Library;

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
            try
            {
                var userName = inputTextBox.Text;
                var greeting = HelloHelper.GetHello(userName);
                ShowSuccessMessage(greeting);
            }
            catch (ArgumentNullException exception)
            {
                ShowErrorMessage($"An error occurred with the following message: {exception.Message}.");
            }
            catch (Exception exception)
            {
                ShowErrorMessage($"An unhandled error occurred with the following message: {exception.Message}.");
            }
        }

        private void ShowSuccessMessage(string greeting)
        {
            MessageBox.Show(greeting, greeting, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowErrorMessage(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
