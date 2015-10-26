namespace PSXCardReader.NET
{
    partial class TextBoxTraceView
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
            this.txtboxTrace = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtboxTrace
            // 
            this.txtboxTrace.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxTrace.Location = new System.Drawing.Point(13, 13);
            this.txtboxTrace.Multiline = true;
            this.txtboxTrace.Name = "txtboxTrace";
            this.txtboxTrace.ReadOnly = true;
            this.txtboxTrace.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtboxTrace.Size = new System.Drawing.Size(702, 416);
            this.txtboxTrace.TabIndex = 0;
            // 
            // TextBoxTraceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 441);
            this.Controls.Add(this.txtboxTrace);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TextBoxTraceView";
            this.Text = "TextBoxTraceView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtboxTrace;
    }
}