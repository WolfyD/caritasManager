namespace CaritasManager
{
	partial class f_belepteto
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
			this.btn_Login = new System.Windows.Forms.Button();
			this.btn_NewProfile = new System.Windows.Forms.Button();
			this.btn_Exit = new System.Windows.Forms.Button();
			this.cb_UserProfile = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tb_Password = new System.Windows.Forms.TextBox();
			this.btn_AllSeeingEye = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btn_Login
			// 
			this.btn_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_Login.Location = new System.Drawing.Point(301, 13);
			this.btn_Login.Name = "btn_Login";
			this.btn_Login.Size = new System.Drawing.Size(75, 29);
			this.btn_Login.TabIndex = 0;
			this.btn_Login.Text = "Belépés";
			this.btn_Login.UseVisualStyleBackColor = true;
			this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
			// 
			// btn_NewProfile
			// 
			this.btn_NewProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_NewProfile.Location = new System.Drawing.Point(301, 47);
			this.btn_NewProfile.Name = "btn_NewProfile";
			this.btn_NewProfile.Size = new System.Drawing.Size(75, 29);
			this.btn_NewProfile.TabIndex = 1;
			this.btn_NewProfile.Text = "Új Profil";
			this.btn_NewProfile.UseVisualStyleBackColor = true;
			this.btn_NewProfile.Click += new System.EventHandler(this.btn_NewProfile_Click);
			// 
			// btn_Exit
			// 
			this.btn_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_Exit.Location = new System.Drawing.Point(301, 92);
			this.btn_Exit.Name = "btn_Exit";
			this.btn_Exit.Size = new System.Drawing.Size(75, 29);
			this.btn_Exit.TabIndex = 2;
			this.btn_Exit.Text = "Kilépés";
			this.btn_Exit.UseVisualStyleBackColor = true;
			this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
			// 
			// cb_UserProfile
			// 
			this.cb_UserProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.cb_UserProfile.FormattingEnabled = true;
			this.cb_UserProfile.Location = new System.Drawing.Point(119, 14);
			this.cb_UserProfile.Name = "cb_UserProfile";
			this.cb_UserProfile.Size = new System.Drawing.Size(176, 26);
			this.cb_UserProfile.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(12, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(101, 18);
			this.label1.TabIndex = 4;
			this.label1.Text = "Belépés mint: ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label2.Location = new System.Drawing.Point(12, 69);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 18);
			this.label2.TabIndex = 5;
			this.label2.Text = "Jelszó: ";
			// 
			// tb_Password
			// 
			this.tb_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
			this.tb_Password.Location = new System.Drawing.Point(119, 66);
			this.tb_Password.Name = "tb_Password";
			this.tb_Password.PasswordChar = '•';
			this.tb_Password.Size = new System.Drawing.Size(146, 24);
			this.tb_Password.TabIndex = 6;
			// 
			// btn_AllSeeingEye
			// 
			this.btn_AllSeeingEye.BackgroundImage = global::CaritasManager.Properties.Resources.eye;
			this.btn_AllSeeingEye.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btn_AllSeeingEye.Location = new System.Drawing.Point(263, 66);
			this.btn_AllSeeingEye.Name = "btn_AllSeeingEye";
			this.btn_AllSeeingEye.Size = new System.Drawing.Size(32, 25);
			this.btn_AllSeeingEye.TabIndex = 7;
			this.btn_AllSeeingEye.UseVisualStyleBackColor = true;
			this.btn_AllSeeingEye.Click += new System.EventHandler(this.btn_AllSeeingEye_Click);
			// 
			// f_belepteto
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(388, 130);
			this.Controls.Add(this.btn_AllSeeingEye);
			this.Controls.Add(this.tb_Password);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cb_UserProfile);
			this.Controls.Add(this.btn_Exit);
			this.Controls.Add(this.btn_NewProfile);
			this.Controls.Add(this.btn_Login);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "f_belepteto";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CaritasManager - Belépés";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btn_Login;
		private System.Windows.Forms.Button btn_NewProfile;
		private System.Windows.Forms.Button btn_Exit;
		private System.Windows.Forms.ComboBox cb_UserProfile;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tb_Password;
		private System.Windows.Forms.Button btn_AllSeeingEye;
	}
}