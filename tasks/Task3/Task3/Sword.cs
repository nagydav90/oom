using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;

namespace Task3
{
	public class Sword : Weapon
	{
		public Sword (string brand, int manufacture_date, double lenght, string owner)
		{
			if (string.IsNullOrWhiteSpace(brand)) throw new ArgumentException("Brand must not be empty.") ;
			if (manufacture_date < 0) throw new Exception("Negative year entered");
			//if (string.IsNullOrWhiteSpace(calibre)) throw new ArgumentException("Calibre must not be empty.", nameof(calibre));

			Brand = brand;
			ManufactureDate = manufacture_date;
			Lenght = lenght;
			Owner = owner;

		}

		public double Lenght { get; }
		#region Weapon implementation
		public string Brand { get; }

		public int ManufactureDate { get; }

		public string Owner { get; set; }

		public void UpdateOwner(string newOwner)
		{

			if (string.IsNullOrWhiteSpace(newOwner)) throw new ArgumentException("Owner name must not be empty.", nameof(newOwner));
			Owner = newOwner;
		}
		#endregion
	}
}

