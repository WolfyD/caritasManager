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
		}

		private void btn_test_Click(object sender, EventArgs e)
		{
			c_DBHandler.createDBFile();
			sqlc = c_DBHandler.connectToDB();
			sqlc.Open();
			c_DBHandler.createTables(sqlc);

			c_DBHandler.addRowToUgyfel(sqlc, "Pogány Dani", "Pogány Dani", "19988776BA", "Szekszárd", "Bada U. 3", "1766.10.12", "Buktabest", 0, "", "McDonalds Frittőzös", "Programozó", "", "", "2018.01.20", "0001");
		}
	}
}
