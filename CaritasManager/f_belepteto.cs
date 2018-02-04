using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;

namespace CaritasManager
{
	public partial class f_belepteto : Form
	{
		SQLiteConnection sqlc;

		public f_belepteto()
		{
			InitializeComponent();

			Load += F_belepteto_Load;
		}

		private void F_belepteto_Load(object sender, EventArgs e)
		{
			sqlc = c_DBHandler.connectToDB();
			sqlc.Open();
			if (!c_DBHandler.checkPassword(sqlc))
			{
				MessageBox.Show("Jelenleg nincs a programban jelszó beállítva.\r\nAz OK gombra kattintás után, megjelenő ablakban állíthat be új érvényes jelszót.", "Nincs jelszó Beállítva", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				f_EditPassword fe = new f_EditPassword();
				fe.empty = true;
				fe.sqlc = sqlc;
				fe.ShowDialog();
			}


		}

		private void btn_AllSeeingEye_Click(object sender, EventArgs e)
		{
			if(tb_Password.PasswordChar == '•')
			{
				tb_Password.PasswordChar = '\0';
			}
			else
			{
				tb_Password.PasswordChar = '•';
			}
		}

		private void btn_Exit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void btn_Login_Click(object sender, EventArgs e)
		{
			//TODO: kezelni a profilokat

			if (c_DBHandler.login(sqlc, tb_Password.Text))
			{
				Form1 f = new Form1();
				this.Hide();
				f.ShowDialog();
				this.Show();
			}
		}

		private void btn_NewProfile_Click(object sender, EventArgs e)
		{
			f_EditProfile ep = new f_EditProfile();
			ep.sqlc = sqlc;
			ep.edit = false;
			ep.ShowDialog();
		}
	}
}
