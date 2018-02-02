using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaritasManager
{
	public partial class uc_Tooltip : UserControl
	{
		public string text { get; set; }
		public Font font { get; set; }

		public uc_Tooltip()
		{
			InitializeComponent();

			Load += Uc_Tooltip_Load;
		}

		private void Uc_Tooltip_Load(object sender, EventArgs e)
		{
			Hide(); 
		}

		private Size getSize(string text)
		{
			Size siz = TextRenderer.MeasureText(text, font);
			siz = new Size(siz.Width + 10, siz.Height + 10);
			
			return siz;
		}

		public void show(Point position)
		{
			show(this.text, position);
		}

		public void show(string text, Point position)
		{
			this.Location = position;
			this.Size = getSize(text);
			lbl_Text.Text = text;
			lbl_Text.Font = font;
			lbl_Text.Location = new Point(5, 5);

			this.Show();
		}

		public void hide()
		{
			this.Size = new Size(1, 1);
			this.Location = new Point(0, 0);
			this.Hide();
		}
	}
}
