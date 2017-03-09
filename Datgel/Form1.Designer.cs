namespace Datgel
{
	partial class Form1
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
			this.pointsGridView = new System.Windows.Forms.DataGridView();
			this.xTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.yTextBox = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.calculateButton = new System.Windows.Forms.Button();
			this.logRichTextBox = new System.Windows.Forms.RichTextBox();
			((System.ComponentModel.ISupportInitialize)(this.pointsGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// pointsGridView
			// 
			this.pointsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.pointsGridView.Location = new System.Drawing.Point(12, 12);
			this.pointsGridView.Name = "pointsGridView";
			this.pointsGridView.RowTemplate.Height = 24;
			this.pointsGridView.Size = new System.Drawing.Size(279, 393);
			this.pointsGridView.TabIndex = 0;
			// 
			// xTextBox
			// 
			this.xTextBox.Location = new System.Drawing.Point(32, 411);
			this.xTextBox.Name = "xTextBox";
			this.xTextBox.Size = new System.Drawing.Size(100, 22);
			this.xTextBox.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 414);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(14, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "x";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(170, 414);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(15, 17);
			this.label2.TabIndex = 4;
			this.label2.Text = "y";
			// 
			// yTextBox
			// 
			this.yTextBox.Location = new System.Drawing.Point(191, 411);
			this.yTextBox.Name = "yTextBox";
			this.yTextBox.Size = new System.Drawing.Size(100, 22);
			this.yTextBox.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 468);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(279, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "Close";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// calculateButton
			// 
			this.calculateButton.Location = new System.Drawing.Point(12, 439);
			this.calculateButton.Name = "calculateButton";
			this.calculateButton.Size = new System.Drawing.Size(279, 23);
			this.calculateButton.TabIndex = 6;
			this.calculateButton.Text = "Calculate";
			this.calculateButton.UseVisualStyleBackColor = true;
			this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
			// 
			// logRichTextBox
			// 
			this.logRichTextBox.Location = new System.Drawing.Point(316, 12);
			this.logRichTextBox.Name = "logRichTextBox";
			this.logRichTextBox.Size = new System.Drawing.Size(260, 475);
			this.logRichTextBox.TabIndex = 7;
			this.logRichTextBox.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(588, 499);
			this.Controls.Add(this.logRichTextBox);
			this.Controls.Add(this.calculateButton);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.yTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.xTextBox);
			this.Controls.Add(this.pointsGridView);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.pointsGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView pointsGridView;
		private System.Windows.Forms.TextBox xTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox yTextBox;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button calculateButton;
		private System.Windows.Forms.RichTextBox logRichTextBox;
	}
}

