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
            this.components = new System.ComponentModel.Container();
            this.mlDirectories = new System.Windows.Forms.TextBox();
            this.bindingSourceViewModel = new System.Windows.Forms.BindingSource(this.components);
            this.panelTop = new System.Windows.Forms.Panel();
            this.pbApply = new System.Windows.Forms.Button();
            this.mlLog = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceViewModel)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // mlDirectories
            // 
            this.mlDirectories.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceViewModel, "Directories", true));
            this.mlDirectories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mlDirectories.Location = new System.Drawing.Point(0, 54);
            this.mlDirectories.Multiline = true;
            this.mlDirectories.Name = "mlDirectories";
            this.mlDirectories.Size = new System.Drawing.Size(673, 271);
            this.mlDirectories.TabIndex = 0;
            // 
            // bindingSourceViewModel
            // 
            this.bindingSourceViewModel.DataSource = typeof(ViewModel);
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
            // mlLog
            // 
            this.mlLog.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceViewModel, "Directories", true));
            this.mlLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mlLog.Location = new System.Drawing.Point(0, 325);
            this.mlLog.Multiline = true;
            this.mlLog.Name = "mlLog";
            this.mlLog.ReadOnly = true;
            this.mlLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mlLog.Size = new System.Drawing.Size(673, 93);
            this.mlLog.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 418);
            this.Controls.Add(this.mlDirectories);
            this.Controls.Add(this.mlLog);
            this.Controls.Add(this.panelTop);
            this.Name = "MainForm";
            this.Text = "AutoGitWatcher";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceViewModel)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox mlDirectories;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button pbApply;
        private System.Windows.Forms.BindingSource bindingSourceViewModel;
        private System.Windows.Forms.TextBox mlLog;
    }
}

