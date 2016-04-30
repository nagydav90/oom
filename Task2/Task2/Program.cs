using System;

namespace Task2
{

	public class Gun
			{

				public Gun(string brand, int manufacture_date, double calibre, string owner)
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

			public string Owner { get; }

		public void UpdateOwner(string owner, string newOwner)
			{
				
				if (string.IsNullOrWhiteSpace(newOwner)) throw new ArgumentException("Owner name must not be empty.", nameof(newOwner));
				owner = newOwner;
			}
		
		}


class Program{
	
		public static void Main ()
		{
			Console.WriteLine ("Hello World!");
		var rifles = new [] 
		{
			new Gun("Colt", 1820, 7.5, "John Doe"),
		};



		}

}
}