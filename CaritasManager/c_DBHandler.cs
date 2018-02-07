using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Data.SQLite;

namespace CaritasManager
{
	public static class c_DBHandler
	{
		public static SHA512CryptoServiceProvider sha5 = new SHA512CryptoServiceProvider();

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
		/// Checks if the current SQLiteConnection (sqlc) is available and open
		/// </summary>
		/// <param name="sqlc">The current SQLiteConnection sqlc</param>
		/// <returns>Bool, true if sqlc is available and open</returns>
		public static bool connectioinOpen(SQLiteConnection sqlc)
		{
			bool ret = false;

			if (sqlc != null && sqlc.State == System.Data.ConnectionState.Open) { ret = true; }

			return ret;
		}

		/// <summary>
		/// Checks if the table 'tableName' exists
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <param name="tableName">The name of the table in question</param>
		/// <returns>Bool, true if the table exists</returns>
		public static bool tableExists(SQLiteConnection sqlc, string tableName)
		{
			bool ret = true;

			SQLiteCommand sqlk = new SQLiteCommand() { Connection = sqlc };
			sqlk.CommandText = ("SELECT name FROM sqlite_master WHERE type='table' AND name='" + tableName + "'");
			if (sqlk.ExecuteScalar() is null) { ret = false; }

			return ret;
		}

		/// <summary>
		/// Runs the executeNonQuery for an SQLiteCommand centrally so I can manage the exceptions
		/// </summary>
		/// <param name="sqlk">SQL Command containing command text and open connection</param>
		/// <returns>Bool, true if command ran successfully</returns>
		public static bool executeNonQuery(SQLiteCommand sqlk)
		{
			bool ret = false;

			if (sqlk.Connection == null || sqlk.Connection.State != System.Data.ConnectionState.Open)
			{
				Console.WriteLine("==================== START EXCEPTION ====================");
				Console.WriteLine("Command has no open connection");
				Console.WriteLine("===================== END EXCEPTION =====================");

				return false;
			}

			try
			{
				sqlk.ExecuteNonQuery();
				ret = true;

			}
			catch (Exception ex)
			{
				Console.WriteLine("\r\n==================== START EXCEPTION ====================");
				Console.WriteLine("=========== c_DBHandler - executeNonQuery (ln:65) ===========");
				Console.WriteLine(ex);
				Console.WriteLine("===================== END EXCEPTION =====================\r\n");
			}

			return ret;
		}

		/// <summary>
		/// Létrehozza a táblákat az adatbázisban
		/// </summary>
		/// <param name="sqlc">Jelenlegi nyitott SQL kapcsolat</param>
		public static void createTables(SQLiteConnection sqlc)
		{
			//Kilép a method-ból, ha nincs nyitott SQLite kapcsolat (sqlc)
			//Ezt minden lekérdezős method-ba beletesszük, hogy ne legyen problémája
			if (!connectioinOpen(sqlc)) { return; }

			SQLiteCommand sqlk = new SQLiteCommand(sqlc);

			//Ellenőrzi, hogy létezik-e a tábla, ha nem, létrehozza
			if (!tableExists(sqlc, "ugyfel"))               //------- UGYFEL tábla
			{
				//TODO: HOZZÁADTA oszlop
				sqlk.CommandText = "CREATE TABLE ugyfel " +
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
										"azonosito TEXT, " +
										"utolso_tamogatas_idopontja TEXT, " +
										"jovedelem_igazolas TEXT, " +
										"allapot TEXT" +
									")";

				executeNonQuery(sqlk);
			}


			if (!tableExists(sqlc, "vagyon"))               //------- VAGYON tábla
			{
				sqlk.CommandText = "CREATE TABLE vagyon " +
									"( " +
										"id INTEGER PRIMARY KEY AUTOINCREMENT, " +
										"ugyfel_id INTEGER, " +
										"szoveg TEXT, " +
										"osszeg INTEGER, " +
										"tipus TEXT" +
									")";

				executeNonQuery(sqlk);
			}

			if (!tableExists(sqlc, "szoc_helyzet"))         //------- SZOCIALIS HELYZET 1 tábla
			{
				sqlk.CommandText = "CREATE TABLE szoc_helyzet " +
									"( " +
										"id INTEGER PRIMARY KEY AUTOINCREMENT, " +
										"ugyfel_id INTEGER, " +
										"lakas INTEGER, " +
										"altalanos_szoc_helyzet INTEGER, " +
										"rendszeres_segitsegre_szorul INTEGER" +
									")";

				executeNonQuery(sqlk);
			}


			if (!tableExists(sqlc, "haztartasban_elok"))    //------- SZOCIALIS HELYZET 2 tábla
			{
				sqlk.CommandText = "CREATE TABLE haztartasban_elok " +
									"( " +
										"id INTEGER PRIMARY KEY AUTOINCREMENT, " +
										"ugyfel_id INTEGER, " +
										"nev TEXT, " +
										"rokoni_kapcsolat TEXT, " +
										"havi_jovedelem INTEGER" +
									")";

				executeNonQuery(sqlk);
			}


			if (!tableExists(sqlc, "tamogatasok"))          //------- TAMOGATASOK tábla
			{
				sqlk.CommandText = "CREATE TABLE tamogatasok " +
									"( " +
										"id INTEGER PRIMARY KEY AUTOINCREMENT, " +
										"ugyfel_id INTEGER, " +
										"datum TEXT, " +
										"tamogatas TEXT" +
									")";

				executeNonQuery(sqlk);
			}


			if (!tableExists(sqlc, "password"))             //------- Felhasználói Profilok
			{
				sqlk.CommandText = "CREATE TABLE password " +
									"( " +
										"id INTEGER PRIMARY KEY AUTOINCREMENT, " +
										"password TEXT" +
									"); INSERT INTO password (password) VALUES ('')";

				executeNonQuery(sqlk);
			}


			if (!tableExists(sqlc, "profilok"))             //------- Felhasználói Profilok
			{
				sqlk.CommandText = "CREATE TABLE profilok " +
									"( " +
										"id INTEGER PRIMARY KEY AUTOINCREMENT, " +
										"profil_name INTEGER, " +
										"last_login TEXT, " +
										"font_family TEXT, " +
										"font_size TEXT, " +
										"font_style TEXT, " +
										"font_color TEXT, " +
										"color_1 TEXT, " +      //zöld ügyfél
										"color_2 TEXT, " +      //sárga ügyfél
										"color_3 TEXT  " +      //piros ügyfél
									")";

				executeNonQuery(sqlk);
			}
		}

		/// <summary>
		/// Connects to the default database file
		/// </summary>
		/// <returns>Current SQLiteConnection</returns>
		public static SQLiteConnection connectToDB()
		{
			SQLiteConnection sqlc = new SQLiteConnection("Data Source=database.sqlite;Version=3;");
			return sqlc;
		}

		/// <summary>
		/// Adds new profile line or edits an existing one
		/// </summary>
		/// <param name="sqlc">Current Open SQLiteConnection</param>
		/// <param name="p">Profile object containing the data to be added</param>
		/// <param name="edit">Bool, if true, new line is not added, but existing one is edited</param>
		/// <returns>String containing error data</returns>
		public static string editProfile(SQLiteConnection sqlc, profile p, bool edit)
		{
			if (!connectioinOpen(sqlc)) { return "ERROR:-1"; }

			string command = string.Format("SELECT id FROM profilok WHERE lower(profil_name)='{0}'", p.name.ToLower());
			SQLiteCommand sqlk = new SQLiteCommand(command, sqlc);

			if (!edit)
			{
				if (sqlk.ExecuteScalar() == null)
				{
					command = string.Format("INSERT INTO profilok (profil_name,last_login,font_family,font_size,font_style,font_color,color_1,color_2,color_3) " +
											" VALUES " +
											" (" +
												"'{0}'," +
												"'{1}'," +
												"'{2}'," +
												"'{3}'," +
												"'{4}'," +
												"'{5}'," +
												"'{6}'," +
												"'{7}'," +
												"'{8}'" +
											");",
												p.name,
												DateTime.Now.ToShortDateString(),
												p.fontFamily,
												p.fontSize,
												p.fontStyle,
												p.fontColor,
												p.color_1,
												p.color_2,
												p.color_3
											);

					sqlk.CommandText = command;
					sqlk.ExecuteNonQuery();

				}
				else
				{
					return "ERROR:0";   //ERROR 0 = Not edit but line already exists
				}
			}
			else
			{
				if (sqlk.ExecuteScalar() != null)
				{
					command = string.Format("UPDATE profilok SET " +
							" last_login='{0}', " +
							" font_family='{1}', " +
							" font_size='{2}'," +
							" font_style='{3}'," +
							" font_color='{4}'," +
							" color_1='{5}'," +
							" color_2='{6}'," +
							" color_3='{7}'" +
						" WHERE lower(profil_name) = '{8}';",
							DateTime.Now.ToShortDateString(),
							p.fontFamily,
							p.fontSize,
							p.fontStyle,
							p.fontColor,
							p.color_1,
							p.color_2,
							p.color_3,
							p.name.ToLower()
						);

					sqlk.CommandText = command;
					sqlk.ExecuteNonQuery();
				}
				else
				{
					return "ERROR:1";   //ERROR 1 = Edit but line doesn't exist yet
				}
			}

			return "";
		}

		/// <summary>
		/// Edits password line //There is only one line in password table
		/// </summary>
		/// <param name="sqlc">Current Open SQLiteConnection</param>
		/// <param name="password">Password string</param>
		public static void editPassword(SQLiteConnection sqlc, string password)
		{
			if (!connectioinOpen(sqlc)) { return; }

			if (password.Length > 0)
			{
				string pwd = password;
				byte[] bytes = Encoding.UTF8.GetBytes(pwd);     //Generates byte[] from string
				pwd = "";
				foreach (byte b in sha5.ComputeHash(bytes))     //Iterates through bytes in array
				{
					pwd += b.ToString("X2");                        //adds new hexadecimal characters to password string (byte.tostring(x2))
				}
				SQLiteCommand sqlk = new SQLiteCommand("UPDATE password SET passwd='" + pwd + "'", sqlc);
				sqlk.ExecuteNonQuery();
			}
		}

		/// <summary>
		/// Login - Checks password againstr the one saved in DB
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <param name="password">String containing password</param>
		/// <returns>Bool, true if Password is OK</returns>
		public static bool login(SQLiteConnection sqlc, string password)
		{
			if (!connectioinOpen(sqlc)) { return false; }

			bool ret = false;
			string pwd = password;
			byte[] bytes = Encoding.UTF8.GetBytes(pwd);
			//pwd = Encoding.UTF8.GetString();
			pwd = "";
			foreach (byte b in sha5.ComputeHash(bytes))
			{
				pwd += b.ToString("X2");
			}

			SQLiteCommand sqlk = new SQLiteCommand("SELECT id FROM password WHERE passwd='" + pwd + "';", sqlc);

			ret = sqlk.ExecuteScalar() == null ? false : true;

			return ret;
		}

		/// <summary>
		/// Checks if password is filled out in DB
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <returns></returns>
		public static bool checkPassword(SQLiteConnection sqlc)
		{
			if (!connectioinOpen(sqlc)) { return false; }

			bool ret = false;

			SQLiteCommand sqlk = new SQLiteCommand("SELECT passwd FROM password WHERE id=1;", sqlc);

			ret = sqlk.ExecuteScalar().ToString() == "" ? false : true;

			return ret;
		}

		#region Új Sor és Módosítás

		//--------------------------- ÜGYFÉL TÁBLA
		/// <summary>
		/// Sort ad hozzá az ugyfel táblához
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConneciton</param>
		/// <param name="nev">Customer name</param>
		/// <param name="születesi_nev">Customer original name</param>
		/// <param name="szig_szam">Customer PID number</param>
		/// <param name="lakcim_varos">Customer Current residence (City)</param>
		/// <param name="lakcim_uh">Customer Current residence (Rest)</param>
		/// <param name="szul_datum">Customer DOB</param>
		/// <param name="szul_hely">Customer City of birth</param>
		/// <param name="csaladi_allapot">Customer Family</param>
		/// <param name="anyja_neve">Customer Mothers name</param>
		/// <param name="vegzettseg">Customer education</param>
		/// <param name="foglalkozas">Customer profession</param>
		/// <param name="szakkepzettseg">Customer Occupational Skills</param>
		/// <param name="munkaltato">Customer employer</param>
		/// <param name="hozzaadas_datuma">Customer Date Added</param>
		/// <param name="azonosito">Customer ID number</param>
		/// <param name="utolso_tamogatas_idopontja">Customer Date of last dupport</param>
		/// <param name="jovedelem_igazolas">Customer income certificate</param>
		/// <param name="allapot">Customer state</param>
		/// <param name="hozzaado_neve">Profile who added customer</param>
		public static void addRowToUgyfel(SQLiteConnection sqlc, string nev, string születesi_nev, string szig_szam,
										string lakcim_varos, string lakcim_uh, string szul_datum,
										string szul_hely, int csaladi_allapot, string anyja_neve,
										string vegzettseg, string foglalkozas, string szakkepzettseg,
										string munkaltato, string hozzaadas_datuma, string azonosito,
										string utolso_tamogatas_idopontja, string jovedelem_igazolas,
										string allapot, string hozzaado_neve)
		{

			if (!connectioinOpen(sqlc)) { return; }

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
													"azonosito," +
													"utolso_tamogatas_idopontja, " +
													"jovedelem_igazolas, " +
													"allapot" +
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
													"'{14}', " +
													"'{15}', " +
													"'{16}', " +
													"'{17}'" +
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
													azonosito,
													utolso_tamogatas_idopontja,
													jovedelem_igazolas,
													allapot
										);

			SQLiteCommand sqlk = new SQLiteCommand(command, sqlc);
			executeNonQuery(sqlk);
		}


		//Ez a bonyolult de szép megoldás
		/// <summary>
		/// Modify or delete line from ugyfel table
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <param name="mod">Data to be modified</param>
		/// <param name="id">ID of row to update/delete</param>
		/// <param name="delete">Bool, if false than update else delete</param>
		public static void modifyUgyfelRow(SQLiteConnection sqlc, Dictionary<String, String> mod, int id, bool delete)
		{
			if (!connectioinOpen(sqlc)) { return; }

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
			executeNonQuery(sqlk);
		}

		//-------------------------- VAGYON TÁBLA
		/// <summary>
		/// Add row to table 'vagyon'
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <param name="ugyfel_id">id of customer</param>
		/// <param name="szoveg">Message of added row</param>
		/// <param name="osszeg">Value of added row</param>
		/// <param name="tipus">Type of added row</param>
		public static void addRowToVagyon(SQLiteConnection sqlc, int ugyfel_id, string szoveg, int osszeg, string tipus)
		{
			if (!connectioinOpen(sqlc)) { return; }

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
			executeNonQuery(sqlk);
		}

		//Csúnyább de sokkal egyszerűbb megoldás iterálás nélkül
		/// <summary>
		/// Update or delete row in table 'vagyon'
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <param name="ugyfel_id">ID of customer</param>
		/// <param name="szoveg">Message of updated row</param>
		/// <param name="osszeg">Value of updated row</param>
		/// <param name="tipus">Type of updated row</param>
		/// <param name="delete">Bool, if true than delete else update</param>
		public static void modifyVagyonRow(SQLiteConnection sqlc, int ugyfel_id, string szoveg, int osszeg, string tipus, bool delete)
		{
			if (!connectioinOpen(sqlc)) { return; }

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
			executeNonQuery(sqlk);
		}

		//-------------------------- SZOCIÁLIS HELYZET TÁBLA
		/// <summary>
		/// Add row to table 'szoc_helyzet'
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <param name="ugyfel_id">ID of customer</param>
		/// <param name="lakas">Type of customer home</param>
		/// <param name="altalanos_szoc_helyzet">Type of customer state</param>
		/// <param name="rendszeres_segitsegre_szorul">Type containing if customer requires constant care</param>
		public static void addRowToSzocHelyzet(SQLiteConnection sqlc, int ugyfel_id, int lakas, int altalanos_szoc_helyzet, int rendszeres_segitsegre_szorul)
		{
			if (!connectioinOpen(sqlc)) { return; }

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
			executeNonQuery(sqlk);
		}

		/// <summary>
		/// Update or delete row from table 'szoc_helyzet'
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <param name="ugyfel_id">ID of customer</param>
		/// <param name="lakas">Type of customer home</param>
		/// <param name="altalanos_szoc_helyzet">Type of customer state</param>
		/// <param name="rendszeres_segitsegre_szorul">Type containing if customer requires constant care</param>
		/// <param name="delete">Bool, if true than delete else update</param>
		public static void modifySzocHelyzet(SQLiteConnection sqlc, int ugyfel_id, int lakas, int altalanos_szoc_helyzet, int rendszeres_segitsegre_szorul, bool delete)
		{
			if (!connectioinOpen(sqlc)) { return; }

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
			executeNonQuery(sqlk);
		}

		//-------------------------- HÁZTARTÁSBAN ÉLŐK TÁBLA
		/// <summary>
		/// Add row to table 'haztartasban_elok'
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <param name="ugyfel_id">ID of customer</param>
		/// <param name="nev">Name of family member</param>
		/// <param name="rokoni_kapcsolat">Type of connection</param>
		/// <param name="havi_jovedelem">Monthly income</param>
		public static void addRowToHaztartasbanElok(SQLiteConnection sqlc, int ugyfel_id, string nev, string rokoni_kapcsolat, int havi_jovedelem)
		{
			if (!connectioinOpen(sqlc)) { return; }

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
			executeNonQuery(sqlk);
		}

		/// <summary>
		/// Update or delete row from table 'haztartasban_elok'
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <param name="ugyfel_id">ID of customer</param>
		/// <param name="nev">Name of family member</param>
		/// <param name="rokoni_kapcsolat">Type of connection</param>
		/// <param name="havi_jovedelem">Monthly income</param>
		/// <param name="delete">Bool, if true than delete else update</param>
		public static void modifyHaztartasbanElok(SQLiteConnection sqlc, int ugyfel_id, string nev, string rokoni_kapcsolat, int havi_jovedelem, bool delete)
		{
			if (!connectioinOpen(sqlc)) { return; }

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
			executeNonQuery(sqlk);
		}

		//-------------------------- TÁMOGATÁSOK TÁBLA
		/// <summary>
		/// Add row to table 'tamogatasok'
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <param name="ugyfel_id">ID of customer</param>
		/// <param name="datum">Date of last support</param>
		/// <param name="tamogatas">Type of support</param>
		public static void addRowToTamogatasok(SQLiteConnection sqlc, int ugyfel_id, string datum, string tamogatas)
		{
			if (!connectioinOpen(sqlc)) { return; }

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
			executeNonQuery(sqlk);

		}

		/// <summary>
		/// Update or delete row from table 'tamogatasok'
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <param name="ugyfel_id">ID of customer</param>
		/// <param name="datum">Date of last support</param>
		/// <param name="tamogatas">Type of support</param>
		/// <param name="delete">Bool, if true than delete else update</param>
		public static void modifyTamogatasok(SQLiteConnection sqlc, int ugyfel_id, string datum, string tamogatas, bool delete)
		{
			if (!connectioinOpen(sqlc)) { return; }

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
			executeNonQuery(sqlk);
		}

		/// <summary>
		/// Check input date, fix if it's faulty
		/// </summary>
		/// <param name="date">String date</param>
		/// <returns>string date (fixed if faulty)</returns>
		public static string checkDate(string date)
		{
			try
			{
				DateTime d = Convert.ToDateTime(date);
				return date;
			}
			catch
			{
				//TODO: helyes dátum létrehozása
				return DateTime.Now.ToShortDateString();
			}
		}

		/// <summary>
		/// Get all rows for the mainData type (the type that is used to fill the main data table)
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <returns>List containing every row in c_MainDataRow objects</returns>
		public static List<c_MainDataRow> getMainRowData(SQLiteConnection sqlc)
		{
			if (!connectioinOpen(sqlc)) { return null; }

			List<c_MainDataRow> lst = new List<c_MainDataRow>();

			string main_command = "SELECT id,nev,jovedelem_igazolas,azonosito,lakcim_varos,lakcim_uh,allapot,hozzaadas_datuma,utolso_tamogatas_idopontja FROM ugyfel";

			SQLiteCommand sqlk = new SQLiteCommand(main_command, sqlc);

			SQLiteDataReader r = sqlk.ExecuteReader();

			while (r.Read())
			{
				c_MainDataRow mdr = new c_MainDataRow();
				mdr.id = r.GetInt32(r.GetOrdinal("id"));
				mdr.name = r.GetString(r.GetOrdinal("nev"));
				mdr.j = (r.GetString(r.GetOrdinal("jovedelem_igazolas")) == "T" ? true : false);
				mdr.identification = r.GetString(r.GetOrdinal("azonosito"));
				mdr.city = r.GetString(r.GetOrdinal("lakcim_varos"));
				mdr.houseno = r.GetString(r.GetOrdinal("lakcim_uh"));
				mdr.state = r.GetString(r.GetOrdinal("allapot"));
				mdr.dateAdded = Convert.ToDateTime(checkDate(r.GetString(r.GetOrdinal("hozzaadas_datuma"))));
				mdr.lastSupport = Convert.ToDateTime(checkDate(r.GetString(r.GetOrdinal("utolso_tamogatas_idopontja"))));
				mdr.kin = new List<string>();

				string kin_command = "SELECT * FROM haztartasban_elok WHERE ugyfel_id=" + mdr.id;
				SQLiteCommand sqlk2 = new SQLiteCommand(kin_command, sqlc);
				SQLiteDataReader rr = sqlk2.ExecuteReader();
				while (rr.Read())
				{
					mdr.kin.Add(rr.GetString(rr.GetOrdinal("rokoni_kapcsolat")) + ":" + rr.GetString(rr.GetOrdinal("nev")));
				}

				lst.Add(mdr);
			}


			return lst;
		}

		#endregion
		
	}

	/// <summary>
	/// Profile Class - 
	/// Contains all data added to the profile table
	/// </summary>
	public class profile
	{
		public string name { get; set; }
		public string fontFamily { get; set; }
		public string fontSize { get; set; }
		public string fontStyle { get; set; }
		public string fontColor { get; set; }
		public string color_1 { get; set; }
		public string color_2 { get; set; }
		public string color_3 { get; set; }
	}

}
