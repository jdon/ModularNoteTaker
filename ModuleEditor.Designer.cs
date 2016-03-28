namespace ModularNoteTaker
{
    partial class ModuleEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModuleEditor));
            this.ModuleName = new System.Windows.Forms.TextBox();
            this.CodeLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.ModuleTitle = new System.Windows.Forms.TextBox();
            this.ModuleSynopsis = new System.Windows.Forms.TextBox();
            this.SynopsisLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ModuelLO = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ModuleName
            // 
            this.ModuleName.Location = new System.Drawing.Point(91, 15);
            this.ModuleName.Name = "ModuleName";
            this.ModuleName.Size = new System.Drawing.Size(228, 20);
            this.ModuleName.TabIndex = 0;
            // 
            // CodeLabel
            // 
            this.CodeLabel.AutoSize = true;
            this.CodeLabel.Location = new System.Drawing.Point(12, 18);
            this.CodeLabel.Name = "CodeLabel";
            this.CodeLabel.Size = new System.Drawing.Size(32, 13);
            this.CodeLabel.TabIndex = 1;
            this.CodeLabel.Text = "Code";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(12, 44);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(27, 13);
            this.TitleLabel.TabIndex = 2;
            this.TitleLabel.Text = "Title";
            // 
            // ModuleTitle
            // 
            this.ModuleTitle.Location = new System.Drawing.Point(91, 41);
            this.ModuleTitle.Name = "ModuleTitle";
            this.ModuleTitle.Size = new System.Drawing.Size(228, 20);
            this.ModuleTitle.TabIndex = 3;
            // 
            // ModuleSynopsis
            // 
            this.ModuleSynopsis.Location = new System.Drawing.Point(91, 67);
            this.ModuleSynopsis.Multiline = true;
            this.ModuleSynopsis.Name = "ModuleSynopsis";
            this.ModuleSynopsis.Size = new System.Drawing.Size(228, 143);
            this.ModuleSynopsis.TabIndex = 5;
            // 
            // SynopsisLabel
            // 
            this.SynopsisLabel.AutoSize = true;
            this.SynopsisLabel.Location = new System.Drawing.Point(12, 70);
            this.SynopsisLabel.Name = "SynopsisLabel";
            this.SynopsisLabel.Size = new System.Drawing.Size(49, 13);
            this.SynopsisLabel.TabIndex = 4;
            this.SynopsisLabel.Text = "Synopsis";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "L.O";
            // 
            // ModuelLO
            // 
            this.ModuelLO.Location = new System.Drawing.Point(91, 216);
            this.ModuelLO.Multiline = true;
            this.ModuelLO.Name = "ModuelLO";
            this.ModuelLO.Size = new System.Drawing.Size(228, 149);
            this.ModuelLO.TabIndex = 7;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(10, 339);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ModuleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 374);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ModuelLO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ModuleSynopsis);
            this.Controls.Add(this.SynopsisLabel);
            this.Controls.Add(this.ModuleTitle);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.CodeLabel);
            this.Controls.Add(this.ModuleName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModuleEditor";
            this.Text = "ModuleEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ModuleName;
        private System.Windows.Forms.Label CodeLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.TextBox ModuleTitle;
        private System.Windows.Forms.TextBox ModuleSynopsis;
        private System.Windows.Forms.Label SynopsisLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ModuelLO;
        private System.Windows.Forms.Button SaveButton;
    }
}