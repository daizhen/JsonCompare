namespace JsonCompare
{
	partial class Form1
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.textBoxOriginal = new System.Windows.Forms.TextBox();
            this.textBoxNew = new System.Windows.Forms.TextBox();
            this.textBoxResultXML = new System.Windows.Forms.TextBox();
            this.buttonCompare = new System.Windows.Forms.Button();
            this.buttonHTML = new System.Windows.Forms.Button();
            this.richTextBoxXSL = new System.Windows.Forms.RichTextBox();
            this.richTextBoxHTML = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxOriginal
            // 
            this.textBoxOriginal.Location = new System.Drawing.Point(12, 42);
            this.textBoxOriginal.Multiline = true;
            this.textBoxOriginal.Name = "textBoxOriginal";
            this.textBoxOriginal.Size = new System.Drawing.Size(534, 276);
            this.textBoxOriginal.TabIndex = 0;
            // 
            // textBoxNew
            // 
            this.textBoxNew.Location = new System.Drawing.Point(587, 42);
            this.textBoxNew.Multiline = true;
            this.textBoxNew.Name = "textBoxNew";
            this.textBoxNew.Size = new System.Drawing.Size(508, 276);
            this.textBoxNew.TabIndex = 1;
            // 
            // textBoxResultXML
            // 
            this.textBoxResultXML.Location = new System.Drawing.Point(12, 324);
            this.textBoxResultXML.Multiline = true;
            this.textBoxResultXML.Name = "textBoxResultXML";
            this.textBoxResultXML.Size = new System.Drawing.Size(534, 276);
            this.textBoxResultXML.TabIndex = 2;
            // 
            // buttonCompare
            // 
            this.buttonCompare.Location = new System.Drawing.Point(1114, 42);
            this.buttonCompare.Name = "buttonCompare";
            this.buttonCompare.Size = new System.Drawing.Size(75, 23);
            this.buttonCompare.TabIndex = 3;
            this.buttonCompare.Text = "Compare";
            this.buttonCompare.UseVisualStyleBackColor = true;
            this.buttonCompare.Click += new System.EventHandler(this.buttonCompare_Click);
            // 
            // buttonHTML
            // 
            this.buttonHTML.Location = new System.Drawing.Point(1114, 102);
            this.buttonHTML.Name = "buttonHTML";
            this.buttonHTML.Size = new System.Drawing.Size(75, 23);
            this.buttonHTML.TabIndex = 4;
            this.buttonHTML.Text = "==>HTML";
            this.buttonHTML.UseVisualStyleBackColor = true;
            this.buttonHTML.Click += new System.EventHandler(this.buttonHTML_Click);
            // 
            // richTextBoxXSL
            // 
            this.richTextBoxXSL.Location = new System.Drawing.Point(587, 324);
            this.richTextBoxXSL.Name = "richTextBoxXSL";
            this.richTextBoxXSL.Size = new System.Drawing.Size(508, 266);
            this.richTextBoxXSL.TabIndex = 5;
            this.richTextBoxXSL.Text = "";
            // 
            // richTextBoxHTML
            // 
            this.richTextBoxHTML.Location = new System.Drawing.Point(12, 618);
            this.richTextBoxHTML.Name = "richTextBoxHTML";
            this.richTextBoxHTML.Size = new System.Drawing.Size(1083, 126);
            this.richTextBoxHTML.TabIndex = 6;
            this.richTextBoxHTML.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1114, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Compare";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 756);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBoxHTML);
            this.Controls.Add(this.richTextBoxXSL);
            this.Controls.Add(this.buttonHTML);
            this.Controls.Add(this.buttonCompare);
            this.Controls.Add(this.textBoxResultXML);
            this.Controls.Add(this.textBoxNew);
            this.Controls.Add(this.textBoxOriginal);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.TextBox textBoxOriginal;
        private System.Windows.Forms.TextBox textBoxNew;
        private System.Windows.Forms.TextBox textBoxResultXML;
        private System.Windows.Forms.Button buttonCompare;
        private System.Windows.Forms.Button buttonHTML;
        private System.Windows.Forms.RichTextBox richTextBoxXSL;
        private System.Windows.Forms.RichTextBox richTextBoxHTML;
        private System.Windows.Forms.Button button1;
	}
}

