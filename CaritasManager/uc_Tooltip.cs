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
		public string title { get; set; }
		public Font font { get; set; }
		public Point position { get; set; }

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
			siz = new Size(siz.Width + 30, siz.Height + 10);

			if(title != "") { siz.Height += 15; }
			
			return siz;
		}

		public void show(Point position)
		{
			show(this.text, position);
		}

		public void show(string text, Point position)
		{
			this.Location = position;
			this.text = text;
			this.Size = new Size(100, 100);
			this.Show();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			this.Size = getSize(text);
			if (title != "")
			{
				e.Graphics.DrawString(title, new Font(font.FontFamily,font.Size - 5, font.Style), Brushes.Black, new Point(5, 5));
				e.Graphics.DrawString(text, font, Brushes.Black, new Point(5, 20));
			}
			else
			{
				e.Graphics.DrawString(text, font, Brushes.Black, new Point(5, 5));
			}
		}

		public void hide()
		{
			this.Size = new Size(1, 1);
			this.Location = new Point(0, 0);
			this.Hide();
		}
	}
}
