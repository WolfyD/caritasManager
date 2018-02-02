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
	public partial class Form1 : Form
	{
		public SQLiteConnection sqlc = null;

		public Form1()
		{
			InitializeComponent();

			Load += Form1_Load;

		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
		

		public void TEST()
		{
			//c_DBHandler.createDBFile();
			sqlc = c_DBHandler.connectToDB();
			sqlc.Open();
			//c_DBHandler.createTables(sqlc);

			//c_DBHandler.addRowToUgyfel(sqlc, "Pogány Dani", "Pogány Dani", "19988776BA", "Szekszárd", "Bada U. 3", "1766.10.12", "Buktabest", 0, "", "McDonalds Frittőzös", "Programozó", "", "", "2018.01.20", "0001", "2018.01.01", "T","OK");


		}

		private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
		{
			if(e.ColumnIndex == 0)
			{
				try
				{
					List<string> k = dg_DataTable[e.ColumnIndex, e.RowIndex].Tag as List<string>;
					string kin = "";

					foreach(string s in k)
					{
						kin += (s.Split(':')[0] + " - ").PadRight(12, ' ');
						kin += s.Split(':')[1] + "\r\n";
					}

					tt_Info.Show(kin, this, new Point(100, 100));
				}
				catch
				{

				}
			}
			//
		}

		private void button1_Click(object sender, EventArgs e)
		{
			TEST();
			List<c_MainDataRow> lst = c_DBHandler.getMainRowData(sqlc);
			int I = 0;

			Bitmap img = new Bitmap(22, 22);
			using(Graphics g = Graphics.FromImage(img))
			{
				g.Clear(Color.White);
				g.DrawString("✓", this.Font, Brushes.Green, new Point(3, 3));
			}

			foreach(c_MainDataRow mdr in lst)
			{
				dg_DataTable.Rows.Insert(I, new object[] { mdr.name + (mdr.kin.Count > 0 ? "(" + mdr.kin.Count + ")" : ""), mdr.j == true ? img : null, mdr.identification, mdr.city, mdr.state, mdr.dateAdded, mdr.lastSupport, "Támogatás" });
				dg_DataTable.Rows[I].Cells[0].Tag = mdr.kin;

				

				I++;
			}

		}
	}
}
