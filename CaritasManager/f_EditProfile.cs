using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaritasManager
{
	public partial class f_EditProfile : Form
	{
		public bool edit = false;
		public SQLiteConnection sqlc { get; set; }
		
		string fontFamily = "";
		string fontSize = "";
		string fontStyle = "";
		string fontColor = "";
		string color_1 = "";
		string color_2 = "";
		string color_3 = "";

		public f_EditProfile()
		{
			InitializeComponent();
		}

		private void btn_SelectFont_Click(object sender, EventArgs e)
		{
			FontDialog fd = new FontDialog();
			if(fd.ShowDialog() == DialogResult.OK)
			{
				fontFamily = fd.Font.FontFamily.Name;
				fontSize = fd.Font.Size.ToString();
				fontStyle = fd.Font.Style.ToString();
			}
		}

		private void p_FontColor_Click(object sender, EventArgs e)
		{
			Panel p = sender as Panel;

			if (p != null)
			{
				ColorDialog cd = new ColorDialog();
				cd.Color = p.BackColor;
				if (cd.ShowDialog() == DialogResult.OK)
				{
					p.BackColor = cd.Color;
				}
			}
		}

		private void btn_Save_Click(object sender, EventArgs e)
		{
			fontColor = p_FontColor.BackColor.ToArgb().ToString();
			color_1 = p_Color1.BackColor.ToArgb().ToString();
			color_2 = p_Color2.BackColor.ToArgb().ToString();
			color_3 = p_Color3.BackColor.ToArgb().ToString();

			profile p = new profile();
			p.name = textBox1.Text;
			p.fontFamily = fontFamily;
			p.fontSize = fontSize;
			p.fontStyle = fontStyle;
			p.fontColor = fontColor;
			p.color_1 = color_1;
			p.color_2 = color_2;
			p.color_3 = color_3;

			c_DBHandler.editProfile(sqlc, p, edit);

		}
	}
}
