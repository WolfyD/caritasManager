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
using System.IO;

namespace CaritasManager
{
	public partial class Form1 : Form
	{
		public SQLiteConnection sqlc = null;
		public bool showKin = false;
		DataGridViewCellEventArgs showKinArgs = null;
		int showKinCheck = 0;

		public Form1()
		{
			InitializeComponent();

			Load += Form1_Load;

		}

		private void Form1_Load(object sender, EventArgs e)
		{
			createIdFile();
		}

		public void createIdFile()
		{
			if (!File.Exists("last_id.ini"))
			{
				File.Create("last_id.ini").Close();

				//TODO: Warn that file changed
			}
		}

		public void TEST()
		{
			c_DBHandler.createDBFile();
			sqlc = c_DBHandler.connectToDB();
			sqlc.Open();
			c_DBHandler.createTables(sqlc);

			c_DBHandler.addRowToUgyfel(sqlc, "Pogány Dani", "Pogány Dani", "19988776BA", "Szekszárd", "Bada U. 3", "1766.10.12", "Buktabest", 0, "", "McDonalds Frittőzös", "Programozó", "", "", "2018.01.20", "0001", "2018.01.01", "T","OK","Marika Néni");


		}


		private void dg_DataTable_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
		{
			showKin = false;
			t_Timer.Stop();
			tt_Tooltip.hide();
		}

		private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 0)
			{
				try
				{
					showKin = true;
					showKinArgs = e;
					showKinCheck = 0;
					t_Timer.Start();
				}
				catch
				{

				}
			}
			else
			{
				showKin = false;
				t_Timer.Stop();
				tt_Tooltip.hide();
			}
			//
		}

		private void ShowKin(DataGridViewCellEventArgs e)
		{
			try
			{
				if(e.RowIndex > -1)
				{
					List<string> k = dg_DataTable[e.ColumnIndex, e.RowIndex].Tag as List<string>;
					string kin = "";

					foreach (string s in k)
					{
						kin += (s.Split(':')[0] + " - ").PadRight(12, ' ');
						kin += s.Split(':')[1] + "\r\n";
					}

					kin = kin.Trim();

					if (kin.Length > 3)
					{
						Point p = PointToClient(Cursor.Position);

						int rowTop = 0;
						int colRight = dg_DataTable[e.ColumnIndex, e.RowIndex].Size.Width;

						rowTop += ts_Tools.Height;
						rowTop += dg_DataTable.ColumnHeadersHeight;
						for (int i = 0; i < e.RowIndex; i++) { rowTop += dg_DataTable[0, i].Size.Height; }
						rowTop -= dg_DataTable.VerticalScrollingOffset;

						tt_Tooltip.font = new Font("Consolas", 14, FontStyle.Regular);
						tt_Tooltip.text = kin;
						tt_Tooltip.title = "Háztartásban élők";
						tt_Tooltip.show(new Point(colRight, rowTop));
					}
					else
					{
						tt_Tooltip.hide();
					}
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			TEST();
			List<c_MainDataRow> lst = c_DBHandler.getMainRowData(sqlc);
			int I = 0;

			Bitmap img = new Bitmap(22, 22);
			using (Graphics g = Graphics.FromImage(img))
			{
				g.Clear(Color.White);
				g.DrawString("✓", this.Font, Brushes.Green, new Point(3, 3));
			}

			foreach (c_MainDataRow mdr in lst)
			{
				DateTime n = DateTime.Now;
				int lasts = (int)Math.Floor((new DateTime(n.Year, n.Month, n.Day) - mdr.lastSupport).TotalDays);


				dg_DataTable.Rows.Insert(I, new object[] { mdr.name + (mdr.kin.Count > 0 ? "  (" + (mdr.kin.Count + 1) + ")" : ""), mdr.j == true ? img : null, mdr.identification, mdr.city, mdr.state, mdr.dateAdded, mdr.lastSupport, "Támogatás" });
				dg_DataTable.Rows[I].Cells[0].Tag = mdr.kin;

				Color c = lasts <= 28 ? Color.LightGreen : (lasts <= 365 ? Color.Orange : Color.LightPink);

				dg_DataTable.Rows[I].DefaultCellStyle.BackColor = c;

				I++;
			}

		}

		private void t_Timer_Tick(object sender, EventArgs e)
		{
			if (showKinCheck >= 8)
			{
				if (showKin == true)
				{
					t_Timer.Stop();
					ShowKin(showKinArgs);
				}
				showKinCheck = 0;
			}

			showKinCheck++;
		}
	}
}
