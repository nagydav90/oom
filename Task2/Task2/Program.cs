using System;
using System.Linq;

namespace Task2
{

class Program{
	
		public static void Main ()
		{
			//Console.WriteLine ("Hello World!");
			var rifles = new [] 
			{
				new Flintlock("Colt", 1820, 7.5, "John Doe"),
				new Flintlock("Collier", 1814, 5, "Sean Mason"),
				new Flintlock("Erberlitz", 1848, 10, "Janos Hunyadi"),
			};

			foreach (var b in rifles)
			{
				Console.WriteLine("{0}, {1}, {2}, {3}", b.Brand, b.ManufactureDate, b.Calibre, b.Owner);
				b.UpdateOwner(b.Owner, "MIA");
				Console.WriteLine("{0}, {1}, {2}, {3}", b.Brand, b.ManufactureDate, b.Calibre, b.Owner);
			}

		

		}

	}
}
