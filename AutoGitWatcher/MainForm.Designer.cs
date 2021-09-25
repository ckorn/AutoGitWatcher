namespace AutoGitWatcher
{
    partial class MainForm
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
            this.dfDirectories = new System.Windows.Forms.TextBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.pbApply = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // dfDirectories
            // 
            this.dfDirectories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dfDirectories.Location = new System.Drawing.Point(0, 54);
            this.dfDirectories.Multiline = true;
            this.dfDirectories.Name = "dfDirectories";
            this.dfDirectories.Size = new System.Drawing.Size(673, 364);
            this.dfDirectories.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.pbApply);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(673, 54);
            this.panelTop.TabIndex = 1;
            // 
            // pbApply
            // 
            this.pbApply.Location = new System.Drawing.Point(14, 12);
            this.pbApply.Name = "pbApply";
            this.pbApply.Size = new System.Drawing.Size(94, 29);
            this.pbApply.TabIndex = 0;
            this.pbApply.Text = "Apply";
            this.pbApply.UseVisualStyleBackColor = true;
            this.pbApply.Click += new System.EventHandler(this.pbApply_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 418);
            this.Controls.Add(this.dfDirectories);
            this.Controls.Add(this.panelTop);
            this.Name = "MainForm";
            this.Text = "AutoGitWatcher";
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox dfDirectories;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button pbApply;
    }
}

