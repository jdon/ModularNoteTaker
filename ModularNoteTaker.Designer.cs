namespace ModularNoteTaker
{
    partial class ModularNoteTaker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModularNoteTaker));
            this.ModuleListBox = new System.Windows.Forms.ListBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DeleteNoteButton = new System.Windows.Forms.Button();
            this.NewNoteButton = new System.Windows.Forms.Button();
            this.NoteListBox = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.AssignmentListBox = new System.Windows.Forms.ListBox();
            this.DeleteModuleButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savedDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moduleFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditModuleButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ModuleListBox
            // 
            this.ModuleListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ModuleListBox.FormattingEnabled = true;
            this.ModuleListBox.Location = new System.Drawing.Point(13, 39);
            this.ModuleListBox.Name = "ModuleListBox";
            this.ModuleListBox.Size = new System.Drawing.Size(260, 329);
            this.ModuleListBox.TabIndex = 0;
            this.ModuleListBox.SelectedIndexChanged += new System.EventHandler(this.ModuleListBox_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(279, 39);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(455, 329);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DeleteNoteButton);
            this.tabPage1.Controls.Add(this.NewNoteButton);
            this.tabPage1.Controls.Add(this.NoteListBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(447, 303);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Notes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DeleteNoteButton
            // 
            this.DeleteNoteButton.Location = new System.Drawing.Point(84, 274);
            this.DeleteNoteButton.Name = "DeleteNoteButton";
            this.DeleteNoteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteNoteButton.TabIndex = 2;
            this.DeleteNoteButton.Text = "Delete Note";
            this.DeleteNoteButton.UseVisualStyleBackColor = true;
            this.DeleteNoteButton.Click += new System.EventHandler(this.DeleteNoteButton_Click);
            // 
            // NewNoteButton
            // 
            this.NewNoteButton.Location = new System.Drawing.Point(3, 274);
            this.NewNoteButton.Name = "NewNoteButton";
            this.NewNoteButton.Size = new System.Drawing.Size(75, 23);
            this.NewNoteButton.TabIndex = 1;
            this.NewNoteButton.Text = "New Note";
            this.NewNoteButton.UseVisualStyleBackColor = true;
            this.NewNoteButton.Click += new System.EventHandler(this.NewNoteButton_Click);
            // 
            // NoteListBox
            // 
            this.NoteListBox.FormattingEnabled = true;
            this.NoteListBox.Location = new System.Drawing.Point(7, 7);
            this.NoteListBox.Name = "NoteListBox";
            this.NoteListBox.Size = new System.Drawing.Size(434, 251);
            this.NoteListBox.TabIndex = 0;
            this.NoteListBox.DoubleClick += new System.EventHandler(this.NoteListBox_DoubleClick_1);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.AssignmentListBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(447, 303);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Assessments";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // AssignmentListBox
            // 
            this.AssignmentListBox.FormattingEnabled = true;
            this.AssignmentListBox.Location = new System.Drawing.Point(7, 7);
            this.AssignmentListBox.Name = "AssignmentListBox";
            this.AssignmentListBox.Size = new System.Drawing.Size(434, 251);
            this.AssignmentListBox.TabIndex = 0;
            this.AssignmentListBox.DoubleClick += new System.EventHandler(this.AssignmentListBox_DoubleClick);
            // 
            // DeleteModuleButton
            // 
            this.DeleteModuleButton.Location = new System.Drawing.Point(13, 374);
            this.DeleteModuleButton.Name = "DeleteModuleButton";
            this.DeleteModuleButton.Size = new System.Drawing.Size(90, 23);
            this.DeleteModuleButton.TabIndex = 3;
            this.DeleteModuleButton.Text = "Delete Module";
            this.DeleteModuleButton.UseVisualStyleBackColor = true;
            this.DeleteModuleButton.Click += new System.EventHandler(this.DeleteModuleButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(738, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savedDataToolStripMenuItem,
            this.moduleFilesToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // savedDataToolStripMenuItem
            // 
            this.savedDataToolStripMenuItem.Name = "savedDataToolStripMenuItem";
            this.savedDataToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.savedDataToolStripMenuItem.Text = "Saved Data";
            this.savedDataToolStripMenuItem.Click += new System.EventHandler(this.savedDataToolStripMenuItem_Click);
            // 
            // moduleFilesToolStripMenuItem
            // 
            this.moduleFilesToolStripMenuItem.Name = "moduleFilesToolStripMenuItem";
            this.moduleFilesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.moduleFilesToolStripMenuItem.Text = "Module Files";
            this.moduleFilesToolStripMenuItem.Click += new System.EventHandler(this.moduleFilesToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // EditModuleButton
            // 
            this.EditModuleButton.Location = new System.Drawing.Point(109, 374);
            this.EditModuleButton.Name = "EditModuleButton";
            this.EditModuleButton.Size = new System.Drawing.Size(75, 23);
            this.EditModuleButton.TabIndex = 5;
            this.EditModuleButton.Text = "View / Edit Module";
            this.EditModuleButton.UseVisualStyleBackColor = true;
            this.EditModuleButton.Click += new System.EventHandler(this.EditModuleButton_Click);
            // 
            // ModularNoteTaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 420);
            this.Controls.Add(this.EditModuleButton);
            this.Controls.Add(this.DeleteModuleButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ModuleListBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ModularNoteTaker";
            this.Text = "Modular Note Taker";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ModuleListBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button DeleteNoteButton;
        private System.Windows.Forms.Button NewNoteButton;
        private System.Windows.Forms.ListBox NoteListBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button DeleteModuleButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savedDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moduleFilesToolStripMenuItem;
        private System.Windows.Forms.ListBox AssignmentListBox;
        private System.Windows.Forms.Button EditModuleButton;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    }
}

