
namespace PSXCardReader.NET
{
    partial class FormMain
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
            this.lblFile = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mmItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mmItemFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mmItemFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(12, 243);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(120, 13);
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "Memory Card File: None";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmItemFile});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mmItemFile
            // 
            this.mmItemFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mmItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmItemFileOpen,
            this.toolStripSeparator1,
            this.mmItemFileExit});
            this.mmItemFile.Name = "mmItemFile";
            this.mmItemFile.Size = new System.Drawing.Size(37, 20);
            this.mmItemFile.Text = "&File";
            // 
            // mmItemFileOpen
            // 
            this.mmItemFileOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mmItemFileOpen.Name = "mmItemFileOpen";
            this.mmItemFileOpen.Size = new System.Drawing.Size(152, 22);
            this.mmItemFileOpen.Text = "&Open...";
            this.mmItemFileOpen.Click += new System.EventHandler(this.mmItemFileOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // mmItemFileExit
            // 
            this.mmItemFileExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mmItemFileExit.Name = "mmItemFileExit";
            this.mmItemFileExit.Size = new System.Drawing.Size(152, 22);
            this.mmItemFileExit.Text = "&Exit";
            this.mmItemFileExit.Click += new System.EventHandler(this.mmItemFileExit_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 265);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "PSXCardReader.NET";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mmItemFile;
        private System.Windows.Forms.ToolStripMenuItem mmItemFileOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mmItemFileExit;
    }
}

