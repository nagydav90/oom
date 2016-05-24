using System;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace Task3
{

class Program{
	
		public static void Main ()
		{
			//Console.WriteLine ("Hello World!");
			var weapons = new Weapon [] 
			{
				new Flintlock("Colt", 1820, 7.5, "John Doe"),
				new Sword("Gorgei", 1867, 120, "Kevin Nagy"),
				new Flintlock("Collier", 1814, 5, "Sean Mason"),
				new Sword("Takahashi", 1892, 100, "Ryouta Tanoue"),
				new Flintlock("Erberlitz", 1848, 10, "Janos Hunyadi"),
			};

			foreach (var b in weapons)
			{
				Console.WriteLine("{0}, {1}, {2}", b.Brand, b.ManufactureDate, b.Owner);
				b.UpdateOwner("MIA");
				Console.WriteLine("{0}, {1}, {2}", b.Brand, b.ManufactureDate, b.Owner);
			}


			var json_array = new Weapon[]
			{
				new Sword("Benpi", 1989, 98, "Walter Smith"),
				new Flintlock("Hinin", 2016, 5.5, "Linda Satou"),
				new Flintlock("Dragonhunter", 1892, 55, "Morath Oghar"),

			};

			string s1 = Newtonsoft.Json.JsonConvert.SerializeObject(json_array, Formatting.Indented);
			Console.WriteLine(s1);

			var json_array2 = Newtonsoft.Json.JsonConvert.DeserializeObject(s1);
			Console.WriteLine(json_array2);

			string path = @"c:\Users\HLord\oom\Task3\Task3\MyTest.txt";

			if (!File.Exists(path))
			{
				File.WriteAllText(path, s1);
			}

			string extraText = "This text shows that append function also works" + Environment.NewLine;

			File.AppendAllText(path, extraText);

			string s2 = File.ReadAllText(path);
			Console.WriteLine(s2);

		}

			
			

	}
}
