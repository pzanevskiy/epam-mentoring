
namespace FileSystemVisitor.Forms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.fileInfoGridView = new System.Windows.Forms.DataGridView();
            this.objName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventView = new System.Windows.Forms.DataGridView();
            this.Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.riseEventsCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.creationTimeFilter = new System.Windows.Forms.DateTimePicker();
            this.nameFilter = new System.Windows.Forms.TextBox();
            this.includeFiles = new System.Windows.Forms.CheckBox();
            this.inclideDirs = new System.Windows.Forms.CheckBox();
            this.includeDate = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileInfoGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(39, 361);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fileInfoGridView
            // 
            this.fileInfoGridView.AllowUserToDeleteRows = false;
            this.fileInfoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fileInfoGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.objName,
            this.CreationTime});
            this.fileInfoGridView.Location = new System.Drawing.Point(12, 12);
            this.fileInfoGridView.Name = "fileInfoGridView";
            this.fileInfoGridView.ReadOnly = true;
            this.fileInfoGridView.RowHeadersWidth = 51;
            this.fileInfoGridView.RowTemplate.Height = 29;
            this.fileInfoGridView.Size = new System.Drawing.Size(640, 343);
            this.fileInfoGridView.TabIndex = 2;
            // 
            // objName
            // 
            this.objName.HeaderText = "Name";
            this.objName.MinimumWidth = 6;
            this.objName.Name = "objName";
            this.objName.ReadOnly = true;
            this.objName.Width = 350;
            // 
            // CreationTime
            // 
            this.CreationTime.HeaderText = "CreationTime";
            this.CreationTime.MinimumWidth = 6;
            this.CreationTime.Name = "CreationTime";
            this.CreationTime.ReadOnly = true;
            this.CreationTime.Width = 150;
            // 
            // eventView
            // 
            this.eventView.AllowUserToAddRows = false;
            this.eventView.AllowUserToDeleteRows = false;
            this.eventView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Event});
            this.eventView.Location = new System.Drawing.Point(676, 12);
            this.eventView.Name = "eventView";
            this.eventView.ReadOnly = true;
            this.eventView.RowHeadersWidth = 51;
            this.eventView.RowTemplate.Height = 29;
            this.eventView.Size = new System.Drawing.Size(664, 343);
            this.eventView.TabIndex = 3;
            // 
            // Event
            // 
            this.Event.HeaderText = "Event";
            this.Event.MinimumWidth = 6;
            this.Event.Name = "Event";
            this.Event.ReadOnly = true;
            this.Event.Width = 500;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(179, 361);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 4;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // riseEventsCheckBox
            // 
            this.riseEventsCheckBox.AutoSize = true;
            this.riseEventsCheckBox.Location = new System.Drawing.Point(676, 361);
            this.riseEventsCheckBox.Name = "riseEventsCheckBox";
            this.riseEventsCheckBox.Size = new System.Drawing.Size(111, 24);
            this.riseEventsCheckBox.TabIndex = 6;
            this.riseEventsCheckBox.Text = "Rise events?";
            this.riseEventsCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(676, 392);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "FileInfo contains";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(676, 431);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Creation time less than";
            // 
            // creationTimeFilter
            // 
            this.creationTimeFilter.Location = new System.Drawing.Point(842, 425);
            this.creationTimeFilter.Name = "creationTimeFilter";
            this.creationTimeFilter.Size = new System.Drawing.Size(250, 27);
            this.creationTimeFilter.TabIndex = 9;
            // 
            // nameFilter
            // 
            this.nameFilter.Location = new System.Drawing.Point(799, 392);
            this.nameFilter.Name = "nameFilter";
            this.nameFilter.Size = new System.Drawing.Size(125, 27);
            this.nameFilter.TabIndex = 10;
            // 
            // includeFiles
            // 
            this.includeFiles.AutoSize = true;
            this.includeFiles.Checked = true;
            this.includeFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeFiles.Location = new System.Drawing.Point(793, 361);
            this.includeFiles.Name = "includeFiles";
            this.includeFiles.Size = new System.Drawing.Size(110, 24);
            this.includeFiles.TabIndex = 11;
            this.includeFiles.Text = "Include files";
            this.includeFiles.UseVisualStyleBackColor = true;
            // 
            // inclideDirs
            // 
            this.inclideDirs.AutoSize = true;
            this.inclideDirs.Location = new System.Drawing.Point(909, 361);
            this.inclideDirs.Name = "inclideDirs";
            this.inclideDirs.Size = new System.Drawing.Size(153, 24);
            this.inclideDirs.TabIndex = 12;
            this.inclideDirs.Text = "Include directories";
            this.inclideDirs.UseVisualStyleBackColor = true;
            // 
            // includeDate
            // 
            this.includeDate.AutoSize = true;
            this.includeDate.Location = new System.Drawing.Point(1098, 427);
            this.includeDate.Name = "includeDate";
            this.includeDate.Size = new System.Drawing.Size(113, 24);
            this.includeDate.TabIndex = 13;
            this.includeDate.Text = "Include date";
            this.includeDate.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 553);
            this.Controls.Add(this.includeDate);
            this.Controls.Add(this.inclideDirs);
            this.Controls.Add(this.includeFiles);
            this.Controls.Add(this.nameFilter);
            this.Controls.Add(this.creationTimeFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.riseEventsCheckBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.eventView);
            this.Controls.Add(this.fileInfoGridView);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.fileInfoGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView fileInfoGridView;
        private System.Windows.Forms.DataGridView eventView;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Event;
        private System.Windows.Forms.CheckBox riseEventsCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn objName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreationTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker creationTimeFilter;
        private System.Windows.Forms.TextBox nameFilter;
        private System.Windows.Forms.CheckBox includeFiles;
        private System.Windows.Forms.CheckBox inclideDirs;
        private System.Windows.Forms.CheckBox includeDate;
    }
}

