namespace CaritasManager
{
	partial class f_EditPassword
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btn_Cancel = new System.Windows.Forms.Button();
			this.btn_SetPassword = new System.Windows.Forms.Button();
			this.btn_AllSeeingEye_Old = new System.Windows.Forms.Button();
			this.tb_OldPassWord = new System.Windows.Forms.TextBox();
			this.tb_NewPassWord = new System.Windows.Forms.TextBox();
			this.btn_AllSeeingEye_New = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Régi Jelszó: ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Új Jelszó: ";
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Location = new System.Drawing.Point(15, 77);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_Cancel.TabIndex = 2;
			this.btn_Cancel.Text = "Mégse";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
			// 
			// btn_SetPassword
			// 
			this.btn_SetPassword.Location = new System.Drawing.Point(309, 77);
			this.btn_SetPassword.Name = "btn_SetPassword";
			this.btn_SetPassword.Size = new System.Drawing.Size(75, 23);
			this.btn_SetPassword.TabIndex = 3;
			this.btn_SetPassword.Text = "Beállítás";
			this.btn_SetPassword.UseVisualStyleBackColor = true;
			this.btn_SetPassword.Click += new System.EventHandler(this.btn_SetPassword_Click);
			// 
			// btn_AllSeeingEye_Old
			// 
			this.btn_AllSeeingEye_Old.BackgroundImage = global::CaritasManager.Properties.Resources.eye;
			this.btn_AllSeeingEye_Old.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btn_AllSeeingEye_Old.Location = new System.Drawing.Point(352, 2);
			this.btn_AllSeeingEye_Old.Name = "btn_AllSeeingEye_Old";
			this.btn_AllSeeingEye_Old.Size = new System.Drawing.Size(32, 26);
			this.btn_AllSeeingEye_Old.TabIndex = 8;
			this.btn_AllSeeingEye_Old.UseVisualStyleBackColor = true;
			this.btn_AllSeeingEye_Old.Click += new System.EventHandler(this.btn_AllSeeingEye_Old_Click);
			// 
			// tb_OldPassWord
			// 
			this.tb_OldPassWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
			this.tb_OldPassWord.Location = new System.Drawing.Point(95, 3);
			this.tb_OldPassWord.Name = "tb_OldPassWord";
			this.tb_OldPassWord.PasswordChar = '•';
			this.tb_OldPassWord.Size = new System.Drawing.Size(259, 24);
			this.tb_OldPassWord.TabIndex = 9;
			// 
			// tb_NewPassWord
			// 
			this.tb_NewPassWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
			this.tb_NewPassWord.Location = new System.Drawing.Point(95, 34);
			this.tb_NewPassWord.Name = "tb_NewPassWord";
			this.tb_NewPassWord.PasswordChar = '•';
			this.tb_NewPassWord.Size = new System.Drawing.Size(259, 24);
			this.tb_NewPassWord.TabIndex = 11;
			// 
			// btn_AllSeeingEye_New
			// 
			this.btn_AllSeeingEye_New.BackgroundImage = global::CaritasManager.Properties.Resources.eye;
			this.btn_AllSeeingEye_New.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btn_AllSeeingEye_New.Location = new System.Drawing.Point(352, 33);
			this.btn_AllSeeingEye_New.Name = "btn_AllSeeingEye_New";
			this.btn_AllSeeingEye_New.Size = new System.Drawing.Size(32, 26);
			this.btn_AllSeeingEye_New.TabIndex = 10;
			this.btn_AllSeeingEye_New.UseVisualStyleBackColor = true;
			this.btn_AllSeeingEye_New.Click += new System.EventHandler(this.btn_AllSeeingEye_New_Click);
			// 
			// f_EditPassword
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(396, 112);
			this.Controls.Add(this.tb_NewPassWord);
			this.Controls.Add(this.btn_AllSeeingEye_New);
			this.Controls.Add(this.tb_OldPassWord);
			this.Controls.Add(this.btn_AllSeeingEye_Old);
			this.Controls.Add(this.btn_SetPassword);
			this.Controls.Add(this.btn_Cancel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "f_EditPassword";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Jelszó Módosítása";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btn_Cancel;
		private System.Windows.Forms.Button btn_SetPassword;
		private System.Windows.Forms.Button btn_AllSeeingEye_Old;
		private System.Windows.Forms.TextBox tb_OldPassWord;
		private System.Windows.Forms.TextBox tb_NewPassWord;
		private System.Windows.Forms.Button btn_AllSeeingEye_New;
	}
}