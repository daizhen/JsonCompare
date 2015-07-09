namespace JsonCompare
{
    partial class TestDiff
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
            this.labelFileName = new System.Windows.Forms.Label();
            this.textBoxTableName = new System.Windows.Forms.TextBox();
            this.textBoxQuery1 = new System.Windows.Forms.TextBox();
            this.labelQuery1 = new System.Windows.Forms.Label();
            this.textBoxQuery2 = new System.Windows.Forms.TextBox();
            this.labelQuery2 = new System.Windows.Forms.Label();
            this.webBrowserResult = new System.Windows.Forms.WebBrowser();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(12, 9);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(68, 13);
            this.labelFileName.TabIndex = 0;
            this.labelFileName.Text = "Table Name:";
            // 
            // textBoxTableName
            // 
            this.textBoxTableName.Location = new System.Drawing.Point(86, 6);
            this.textBoxTableName.Name = "textBoxTableName";
            this.textBoxTableName.Size = new System.Drawing.Size(395, 20);
            this.textBoxTableName.TabIndex = 1;
            // 
            // textBoxQuery1
            // 
            this.textBoxQuery1.Location = new System.Drawing.Point(86, 32);
            this.textBoxQuery1.Name = "textBoxQuery1";
            this.textBoxQuery1.Size = new System.Drawing.Size(395, 20);
            this.textBoxQuery1.TabIndex = 3;
            // 
            // labelQuery1
            // 
            this.labelQuery1.AutoSize = true;
            this.labelQuery1.Location = new System.Drawing.Point(12, 35);
            this.labelQuery1.Name = "labelQuery1";
            this.labelQuery1.Size = new System.Drawing.Size(44, 13);
            this.labelQuery1.TabIndex = 2;
            this.labelQuery1.Text = "Query1:";
            // 
            // textBoxQuery2
            // 
            this.textBoxQuery2.Location = new System.Drawing.Point(583, 35);
            this.textBoxQuery2.Name = "textBoxQuery2";
            this.textBoxQuery2.Size = new System.Drawing.Size(395, 20);
            this.textBoxQuery2.TabIndex = 5;
            // 
            // labelQuery2
            // 
            this.labelQuery2.AutoSize = true;
            this.labelQuery2.Location = new System.Drawing.Point(509, 38);
            this.labelQuery2.Name = "labelQuery2";
            this.labelQuery2.Size = new System.Drawing.Size(44, 13);
            this.labelQuery2.TabIndex = 4;
            this.labelQuery2.Text = "Query2:";
            // 
            // webBrowserResult
            // 
            this.webBrowserResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.webBrowserResult.Location = new System.Drawing.Point(0, 61);
            this.webBrowserResult.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserResult.Name = "webBrowserResult";
            this.webBrowserResult.Size = new System.Drawing.Size(1420, 708);
            this.webBrowserResult.TabIndex = 6;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(1006, 33);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "GO";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // TestDiff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1420, 769);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.webBrowserResult);
            this.Controls.Add(this.textBoxQuery2);
            this.Controls.Add(this.labelQuery2);
            this.Controls.Add(this.textBoxQuery1);
            this.Controls.Add(this.labelQuery1);
            this.Controls.Add(this.textBoxTableName);
            this.Controls.Add(this.labelFileName);
            this.Name = "TestDiff";
            this.Text = "TestDiff";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.TextBox textBoxTableName;
        private System.Windows.Forms.TextBox textBoxQuery1;
        private System.Windows.Forms.Label labelQuery1;
        private System.Windows.Forms.TextBox textBoxQuery2;
        private System.Windows.Forms.Label labelQuery2;
        private System.Windows.Forms.WebBrowser webBrowserResult;
        private System.Windows.Forms.Button buttonOK;
    }
}