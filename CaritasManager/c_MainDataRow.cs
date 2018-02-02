using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaritasManager
{
	public class c_MainDataRow
	{
		/// <summary>
		/// Ügyfél ID
		/// </summary>
		public int id { get; set; }

		/// <summary>
		/// Ügyfél neve
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// Jövedelem igazolását leadta
		/// </summary>
		public bool j { get; set; }

		/// <summary>
		/// Ügyfél azonosító száma eg: 001112
		/// </summary>
		public string identification { get; set; }

		/// <summary>
		/// Ügyfél lakhelye (Város)
		/// </summary>
		public string city { get; set; }

		/// <summary>
		/// Ügyfél lakhelye (Utca, Házszám)
		/// </summary>
		public string houseno { get; set; }

		/// <summary>
		/// Ügyfél állapota
		/// </summary>
		public string state { get; set; }

		/// <summary>
		/// Mikor lett felvéve az ügyfél az adatbázisba (SDT)
		/// </summary>
		public DateTime dateAdded { get; set; }

		/// <summary>
		/// Mikor kapott utoljára segélyt az ügyfél
		/// </summary>
		public DateTime lastSupport { get; set; }

		/// <summary>
		/// Ügyfél hozzátartozói
		/// </summary>
		public List<string> kin { get; set; }
	}


}
