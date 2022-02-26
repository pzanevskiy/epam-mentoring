
namespace Fundametals.WinFroms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.inputlabel = new System.Windows.Forms.Label();
            this.helloButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inputTextBox
            // 
            this.inputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputTextBox.Location = new System.Drawing.Point(192, 6);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(120, 30);
            this.inputTextBox.TabIndex = 0;
            // 
            // inputlabel
            // 
            this.inputlabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputlabel.AutoSize = true;
            this.inputlabel.BackColor = System.Drawing.SystemColors.Control;
            this.inputlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputlabel.Location = new System.Drawing.Point(12, 9);
            this.inputlabel.Name = "inputlabel";
            this.inputlabel.Size = new System.Drawing.Size(153, 25);
            this.inputlabel.TabIndex = 1;
            this.inputlabel.Text = "Input username:";
            // 
            // helloButton
            // 
            this.helloButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helloButton.Location = new System.Drawing.Point(310, 194);
            this.helloButton.Name = "helloButton";
            this.helloButton.Size = new System.Drawing.Size(163, 56);
            this.helloButton.TabIndex = 2;
            this.helloButton.Text = "Press to Hello!";
            this.helloButton.UseVisualStyleBackColor = true;
            this.helloButton.Click += new System.EventHandler(this.helloButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.helloButton);
            this.Controls.Add(this.inputlabel);
            this.Controls.Add(this.inputTextBox);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Label inputlabel;
        private System.Windows.Forms.Button helloButton;
    }
}

