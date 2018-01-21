using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;

namespace CaritasManager
{
	public static class c_DBHandler
	{
		/// <summary>
		/// Létrehozza a DB fájlt
		/// </summary>
		public static void createDBFile()
		{
			if (!File.Exists("database.sqlite"))
			{
				File.Create("database.sqlite").Close();
			}
		}

		/// <summary>
		/// Létrehozza a táblákat az adatbázisban
		/// </summary>
		/// <param name="sqlc">Jelenlegi nyitott SQL kapcsolat</param>
		public static void createTables(SQLiteConnection sqlc)
		{
			//------- UGYFEL tábla
			
			SQLiteCommand sqlk = new SQLiteCommand("CREATE TABLE ugyfel " + 
															"(" + 
																"id INTEGER PRIMARY KEY AUTOINCREMENT, " + 
																"nev TEXT, " + 
																"születesi_nev TEXT, " + 
																"szig_szam TEXT, " + 
																"lakcim_varos TEXT, " + 
																"lakcim_uh TEXT, " + 
																"szul_datum TEXT, " + 
																"szul_hely TEXT, " + 
																"csaladi_allapot INTEGER, " +
																"anyja_neve TEXT, " +
																"vegzettseg TEXT, " +
																"foglalkozas TEXT, " +
																"szakkepzettseg TEXT, " +
																"munkaltato TEXT, " +
																"hozzaadas_datuma TEXT, " + 
																"azonosito TEXT" + 
															")", sqlc);
			sqlk.Connection = sqlc;
			sqlk.ExecuteNonQuery();

			//------- VAGYON tábla

			sqlk.CommandText = "CREATE TABLE vagyon " + 
											"( " +
												"id INTEGER PRIMARY KEY AUTOINCREMENT, " +
												"ugyfel_id INTEGER, " +
												"szoveg TEXT, " +
												"osszeg INTEGER, " +
												"tipus TEXT" +
											")";

			sqlk.ExecuteNonQuery();

			//------- SZOCIALIS HELYZET 1 tábla

			sqlk.CommandText = "CREATE TABLE szoc_helyzet " +
											"( " +
												"id INTEGER PRIMARY KEY AUTOINCREMENT, " +
												"ugyfel_id INTEGER, " +
												"lakas INTEGER, " +
												"altalanos_szoc_helyzet INTEGER, " +
												"rendszeres_segitsegre_szorul INTEGER" + 
											")";

			sqlk.ExecuteNonQuery();

			//------- SZOCIALIS HELYZET 2 tábla

			sqlk.CommandText = "CREATE TABLE haztartasban_elok " +
											"( " +
												"id INTEGER PRIMARY KEY AUTOINCREMENT, " +
												"ugyfel_id INTEGER, " +
												"nev TEXT, " +
												"rokoni_kapcsolat TEXT, " +
												"havi_jovedelem INTEGER" +
											")";

			sqlk.ExecuteNonQuery();

			//------- TAMOGATASOK tábla

			sqlk.CommandText = "CREATE TABLE tamogatasok " +
											"( " +
												"id INTEGER PRIMARY KEY AUTOINCREMENT, " +
												"ugyfel_id INTEGER, " +
												"datum TEXT, " +
												"tamogatas TEXT" +
											")";

			sqlk.ExecuteNonQuery();
		}


		public static SQLiteConnection connectToDB()
		{
			SQLiteConnection sqlc = new SQLiteConnection("Data Source=database.sqlite;Version=3;");
			return sqlc;
		}


		#region Új Sor és Módosítás

		//--------------------------- ÜGYFÉL TÁBLA

		/// <summary>
		/// Sort ad hozzá az ugyfel táblához
		/// </summary>
		public static void addRowToUgyfel(SQLiteConnection sqlc, string nev, string születesi_nev, string szig_szam, 
										string lakcim_varos, string lakcim_uh, string szul_datum, 
										string szul_hely, int csaladi_allapot, string anyja_neve, 
										string vegzettseg, string foglalkozas, string szakkepzettseg, 
										string munkaltato, string hozzaadas_datuma, string azonosito)
		{

			string command = string.Format(
												"INSERT INTO ugyfel " +
												"(" +
													"nev, " +
													"születesi_nev, " +
													"szig_szam, " +
													"lakcim_varos, " +
													"lakcim_uh, " +
													"szul_datum, " +
													"szul_hely, " +
													"csaladi_allapot, " +
													"anyja_neve, " +
													"vegzettseg, " +
													"foglalkozas, " +
													"szakkepzettseg, " +
													"munkaltato, " +
													"hozzaadas_datuma, " +
													"azonosito" +
												") VALUES (" +
													"'{0}', " +
													"'{1}', " +
													"'{2}', " + 
													"'{3}', " +
													"'{4}', " +
													"'{5}', " +
													"'{6}', " +
													"{7}, " +
													"'{8}', " +
													"'{9}', " +
													"'{10}', " +
													"'{11}', " +
													"'{12}', " +
													"'{13}', " +
													"'{14}' " +
												")", 
													nev, 
													születesi_nev, 
													szig_szam, 
													lakcim_varos, 
													lakcim_uh, 
													szul_datum, 
													szul_hely, 
													csaladi_allapot, 
													anyja_neve, 
													vegzettseg, 
													foglalkozas, 
													szakkepzettseg, 
													munkaltato, 
													hozzaadas_datuma, 
													azonosito
										);

			SQLiteCommand sqlk = new SQLiteCommand(command, sqlc);
			sqlk.ExecuteNonQuery();

		}
		

		//Ez a bonyolult de szép megoldás
		public static void modifyUgyfelRow(SQLiteConnection sqlc, Dictionary<String,String> mod, int id, bool delete)
		{
			String command = "";

			if (delete)
			{
				command = "DELETE FROM ugyfel WHERE id=" + id;
			}
			else
			{
				command = "UPDATE ugyfel SET ";

				foreach (KeyValuePair<string, string> kvp in mod)
				{
					if (kvp.Key == "csaladi_allapot")
					{
						command += kvp.Key + "=" + kvp.Value;
					}
					else
					{
						command += kvp.Key + "= '" + kvp.Value + "' ";
					}

					if (mod.Last().Key != kvp.Key)
					{
						command += ", ";
					}
				}

				command += " WHERE id=" + id;
			}

			SQLiteCommand sqlk = new SQLiteCommand(command, sqlc);
			sqlk.ExecuteNonQuery();
		}

		//-------------------------- VAGYON TÁBLA

		public static void addRowToVagyon(SQLiteConnection sqlc, int ugyfel_id, string szoveg, int osszeg, string tipus)
		{
			string command = string.Format("INSERT INTO vagyon " +
												"(" +
													"ugyfel_id, " +
													"szoveg, " +
													"osszeg, " +
													"tipus " +
												") VALUES (" +
													"'{0}', " +
													"'{1}', " +
													"{2}, " +
													"'{3}' " +
												")", 
													ugyfel_id,
													szoveg,
													osszeg,
													tipus
										);

			SQLiteCommand sqlk = new SQLiteCommand(command, sqlc);
			sqlk.ExecuteNonQuery();
		}

		//Csúnyább de sokkal egyszerűbb megoldás iterálás nélkül
		public static void modifyVagyonRow(SQLiteConnection sqlc, int ugyfel_id, string szoveg, int osszeg, string tipus, bool delete)
		{
			string command = "";

			if (delete)
			{
				command = string.Format("DELETE FROM vagyon WHERE ugyfel_id={0}", ugyfel_id);
			}
			else
			{
				command = string.Format("UPDATE vagyon SET szoveg='{0}', osszeg={1}, tipus='{2}' WHERE ugyfel_id={3}", szoveg, osszeg, tipus, ugyfel_id);
			}

			SQLiteCommand sqlk = new SQLiteCommand(command, sqlc);
			sqlk.ExecuteNonQuery();
		}


		public static void addRowToSzocHelyzet(SQLiteConnection sqlc, int ugyfel_id, int lakas, int altalanos_szoc_helyzet, int rendszeres_segitsegre_szorul)
		{
			string command = string.Format("INSERT INTO szoc_helyzet " +
												"(" +
													"ugyfel_id, " +
													"lakas, " +
													"altalanos_szoc_helyzet, " +
													"rendszeres_segitsegre_szorul" +
												") VALUES (" +
													"{0}," +
													"{1}," +
													"{2}," +
													"{3}" +
												")",
													ugyfel_id,
													lakas,
													altalanos_szoc_helyzet,
													rendszeres_segitsegre_szorul
										);

			SQLiteCommand sqlk = new SQLiteCommand(command, sqlc);
			sqlk.ExecuteNonQuery();
		}

		public static void modifySzocHelyzet(SQLiteConnection sqlc, int ugyfel_id, int lakas, int altalanos_szoc_helyzet, int rendszeres_segitsegre_szorul, bool delete)
		{
			string command = "";
			if (delete)
			{
				command = string.Format("DELETE FROM szoc_helyzet WHERE ugyfel_id={0}", ugyfel_id);
			}
			else
			{
				command = string.Format("UPDATE szoc_helyzet SET lakas={0}, altalanos_szoc_helyzet={1}, rendszeres_segitsegre_szorul={2} WHERE ugyfel_id={3}",
				lakas, altalanos_szoc_helyzet, rendszeres_segitsegre_szorul, ugyfel_id);
			}

			SQLiteCommand sqlk = new SQLiteCommand(command, sqlc);
			sqlk.ExecuteNonQuery();
		}

		public static void addRowToHaztartasbanElok(SQLiteConnection sqlc, int ugyfel_id, string nev, string rokoni_kapcsolat, int havi_jovedelem)
		{
			string command = string.Format("INSERT INTO  haztartasban_elok " +
											"(" +
												"ugyfel_id, " +
												"nev, " +
												"rokoni_kapcsolat, " +
												"havi_jovedelem " +
											") VALUES (" +
												"{0}," +
												"'{1}'," +
												"'{2}'," +
												"{3}" +
											")",
												ugyfel_id,
												nev,
												rokoni_kapcsolat,
												havi_jovedelem
											);
			SQLiteCommand sqlk = new SQLiteCommand(command, sqlc);
			sqlk.ExecuteNonQuery();
		}

		public static void modifyHaztartasbanElok(SQLiteConnection sqlc, int ugyfel_id, string nev, string rokoni_kapcsolat, int havi_jovedelem, bool delete)
		{
			string command = "";
			
			if (delete)
			{
				command = string.Format("DELETE FROM haztartasban_elok WHERE ugyfel_id={0}", ugyfel_id);
			}
			else
			{
				command = string.Format("UPDATE haztartasban_elok SET nev='{0}', rokoni_kapcsolat='{1}', havi_jovedelem={2} WHERE ugyfel_id={3}",
				nev, rokoni_kapcsolat, havi_jovedelem, ugyfel_id);
			}

			SQLiteCommand sqlk = new SQLiteCommand(command, sqlc);
			sqlk.ExecuteNonQuery();
		}

		public static void addRowToTamogatasok(SQLiteConnection sqlc, int ugyfel_id, string datum, string tamogatas)
		{
			string command = string.Format("INSERT INTO tamogatasok " +
												"(" +
													"ugyfel_id, " +
													"datum, " +
													"tamogatas " +
												") VALUES (" +
													"{0}, " +
													"'{1}', " +
													"'{2}' " +
												")",
													ugyfel_id,
													datum,
													tamogatas
											);
			SQLiteCommand sqlk = new SQLiteCommand(command, sqlc);
			sqlk.ExecuteNonQuery();

		}

		public static void modifyTamogatasok(SQLiteConnection sqlc, int ugyfel_id, string datum, string tamogatas, bool delete)
		{
			string command = "";

			if (delete)
			{
				command = "DELETE FROM tamogatasok WHERE ugyfel_id=" + ugyfel_id;
			}
			else
			{
				command = "UPDATE tamogatasok SET datum='" + datum + "', tamogatas='" + tamogatas + "' WHERE ugyfel_id=" + ugyfel_id; 
			}

			SQLiteCommand sqlk = new SQLiteCommand(command, sqlc);
			sqlk.ExecuteNonQuery();
		}

	#endregion



	}

}
