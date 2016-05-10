using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;

namespace Task2
{

	public class Flintlock
		{

				public Flintlock(string brand, int manufacture_date, double calibre, string owner)
				{
					if (string.IsNullOrWhiteSpace(brand)) throw new ArgumentException("Brand must not be empty.", nameof(brand));
					if (manufacture_date < 0) throw new Exception("Negative year entered");
					//if (string.IsNullOrWhiteSpace(calibre)) throw new ArgumentException("Calibre must not be empty.", nameof(calibre));

					Brand = brand;
					ManufactureDate = manufacture_date;
					Calibre = calibre;
					Owner = owner;

				}
		
			public string Brand { get; }

			public int ManufactureDate { get; }

			public double Calibre { get; }

			public string Owner { get; set; }

		public void UpdateOwner(string newOwner)
			{
				
				if (string.IsNullOrWhiteSpace(newOwner)) throw new ArgumentException("Owner name must not be empty.", nameof(newOwner));
				Owner = newOwner;
			}
		
		}
}
