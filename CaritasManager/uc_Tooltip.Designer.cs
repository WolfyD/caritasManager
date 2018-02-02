namespace CaritasManager
{
	partial class uc_Tooltip
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lbl_Text = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lbl_Text
			// 
			this.lbl_Text.AutoSize = true;
			this.lbl_Text.Location = new System.Drawing.Point(15, 9);
			this.lbl_Text.Name = "lbl_Text";
			this.lbl_Text.Size = new System.Drawing.Size(35, 13);
			this.lbl_Text.TabIndex = 0;
			this.lbl_Text.Text = "label1";
			// 
			// uc_Tooltip
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightYellow;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.lbl_Text);
			this.Name = "uc_Tooltip";
			this.Size = new System.Drawing.Size(194, 86);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbl_Text;
	}
}
