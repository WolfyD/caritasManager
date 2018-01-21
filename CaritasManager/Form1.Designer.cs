namespace CaritasManager
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
			this.btn_test = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btn_test
			// 
			this.btn_test.Location = new System.Drawing.Point(24, 22);
			this.btn_test.Name = "btn_test";
			this.btn_test.Size = new System.Drawing.Size(75, 23);
			this.btn_test.TabIndex = 0;
			this.btn_test.Text = "TESZT";
			this.btn_test.UseVisualStyleBackColor = true;
			this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(723, 511);
			this.Controls.Add(this.btn_test);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btn_test;
	}
}

