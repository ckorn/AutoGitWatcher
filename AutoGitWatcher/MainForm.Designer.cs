namespace UI.AutoGitWatcher
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
            this.pbPull = new System.Windows.Forms.Button();
            this.pbPush = new System.Windows.Forms.Button();
            this.mlLog = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceViewModel)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // mlDirectories
            // 
            this.mlDirectories.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceViewModel, "Directories", true));
            this.mlDirectories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mlDirectories.Location = new System.Drawing.Point(0, 40);
            this.mlDirectories.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mlDirectories.Multiline = true;
            this.mlDirectories.Name = "mlDirectories";
            this.mlDirectories.Size = new System.Drawing.Size(589, 203);
            this.mlDirectories.TabIndex = 0;
            // 
            // bindingSourceViewModel
            // 
            this.bindingSourceViewModel.DataSource = typeof(ViewModel);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.pbPull);
            this.panelTop.Controls.Add(this.pbPush);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(589, 40);
            this.panelTop.TabIndex = 1;
            // 
            // pbPull
            // 
            this.pbPull.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bindingSourceViewModel, "EnableGui", true));
            this.pbPull.Location = new System.Drawing.Point(100, 9);
            this.pbPull.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbPull.Name = "pbPull";
            this.pbPull.Size = new System.Drawing.Size(82, 22);
            this.pbPull.TabIndex = 1;
            this.pbPull.Text = "Pull";
            this.pbPull.UseVisualStyleBackColor = true;
            this.pbPull.Click += new System.EventHandler(this.pbPull_Click);
            // 
            // pbPush
            // 
            this.pbPush.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bindingSourceViewModel, "EnableGui", true));
            this.pbPush.Location = new System.Drawing.Point(12, 9);
            this.pbPush.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbPush.Name = "pbPush";
            this.pbPush.Size = new System.Drawing.Size(82, 22);
            this.pbPush.TabIndex = 0;
            this.pbPush.Text = "Push";
            this.pbPush.UseVisualStyleBackColor = true;
            this.pbPush.Click += new System.EventHandler(this.pbApply_Click);
            // 
            // mlLog
            // 
            this.mlLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mlLog.Location = new System.Drawing.Point(0, 243);
            this.mlLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mlLog.Multiline = true;
            this.mlLog.Name = "mlLog";
            this.mlLog.ReadOnly = true;
            this.mlLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mlLog.Size = new System.Drawing.Size(589, 71);
            this.mlLog.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 314);
            this.Controls.Add(this.mlDirectories);
            this.Controls.Add(this.mlLog);
            this.Controls.Add(this.panelTop);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.Button pbPush;
        private System.Windows.Forms.BindingSource bindingSourceViewModel;
        private System.Windows.Forms.TextBox mlLog;
        private System.Windows.Forms.Button pbPull;
    }
}

