using System;
using System.Linq;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;


namespace Task3
{

	class Program
	{

		public static void Main()
		{
			/*Let's make a new array of both classes based on weapons*/
			var weapons = new Weapon[]
			{
				new Flintlock("Colt", 1820, 7.5, "John Doe"),
				new Sword("Gorgei", 1867, 120, "Kevin Nagy"),
				new Flintlock("Collier", 1814, 5, "Sean Mason"),
				new Sword("Takahashi", 1892, 100, "Ryouta Tanoue"),
				new Flintlock("Erberlitz", 1848, 10, "Janos Hunyadi"),
			};
			/*Try UpdateOwner inherited class operation and print both pre and after to see change*/
			foreach (var b in weapons)
			{
				Console.WriteLine("{0}, {1}, {2}", b.Brand, b.ManufactureDate, b.Owner);
				b.UpdateOwner("MIA");
				Console.WriteLine("{0}, {1}, {2}", b.Brand, b.ManufactureDate, b.Owner);
			}

			/*Make a new array for serializing*/
			var json_array = new Weapon[]
			{
				new Sword("Benpi", 1989, 98, "Walter Smith"),
				new Flintlock("Hinin", 2016, 5.5, "Linda Satou"),
				new Flintlock("Dragonhunter", 1892, 55, "Morath Oghar"),

			};

			/*Settings to enable correct formatting in the serializer*/
			var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };

			/*Serialize the array of weapons into string*/
			string s1 = JsonConvert.SerializeObject(json_array, settings);
			/*Print out the string*/
			Console.WriteLine("Here comes the serilized string!" + Environment.NewLine + s1 + Environment.NewLine);

			/*Deserialize into a list of weapons*/
			var json_array2 = JsonConvert.DeserializeObject<List<Weapon>>(s1, settings);
			/*Print out deserialized list, I believe the 4th class specific parameter could also be printed out with some ifs*/
			Console.WriteLine("The deserialized ones:" + Environment.NewLine);
			json_array2.ForEach(x => Console.WriteLine("{0}, {1}, {2}", x.Brand, x.ManufactureDate, x.Owner));

			/*Setting the path to the file for the serialized string*/
			string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "tests.txt");

			/*If the file does not exist yet, write the string in it*/
			if (!File.Exists(path))
			{
				File.WriteAllText(path, s1);
			}


			/*Play with the append function*/
			string extraText = "This text shows that append function also works" + Environment.NewLine;
			File.AppendAllText(path, extraText);

			/*Ride the created file*/
			string s2 = File.ReadAllText(path);
			Console.WriteLine("Here comes the file read in" + Environment.NewLine + s2);

			/*****
			* 
			* Task 6.1
			* 
			* Try out the Subject pushing a list of swords to the program
			*
			******/
			/*Setup for the subject and preparing for the arrival of new Sword objects by making a list*/
			var rx_list = new List<Sword>();
			var producer = new Subject<Sword>();
			producer.Subscribe(value => rx_list.Add(value));

			/*Define the new thread that waits and the pushes 10 new objects on to the main thread*/
			var t = new Thread(() =>
			{
				for (var i = 0; i < 10; i++)
				{
					Thread.Sleep(TimeSpan.FromSeconds(1));
					producer.OnNext(new Sword("Achilles", (2016 + i), (1 * i), "Unknown")); // push sword data to console with some influence based on i variable
				}
			});

			/*Time to try out the new thread*/
			t.Start();
			/*Let the main thread wait for the result*/
			Thread.Sleep(TimeSpan.FromSeconds(12));
			/*Print out the results*/
			rx_list.ForEach(x => Console.WriteLine("{0}, {1}, {2}, {3}", x.Brand, x.ManufactureDate, x.Lenght, x.Owner));

			/*****
			* 
			* Task 6.2
			* 
			* Multiple tries with asynchronity and tasks/threads
			*
			******/

			/*Try out running a task */
			var result = Task.Run(() => DosomethingWeird("Task"));
			Console.WriteLine(result.Result);

			/*Setting up webclient and uri for upcoming requests*/
			var client = new WebClient();
			var uri1 = new System.Uri("http://www.msdn.microsoft.com");
			var uri2 = new System.Uri("http://www.index.hu");

			/*Just a try at making a new thread*/
			var task2 = new Thread(() =>
			{
				client.DownloadString(uri1);

			});

			/*Let us see .ContinueWith*/
			Task<string> futureData = DownloadStringMethod2(uri2);
			futureData.ContinueWith(y => Console.WriteLine(y.Result));


			/*Try an asynchron function*/
			Task<string> urlContent = DownloadStringMethod2(uri2);
			Console.WriteLine(urlContent.Result);
		}
		/*Simple function for a new task*/
		static string DosomethingWeird(String s)
		{
			var endTime = DateTime.Now.AddSeconds(10);

			while (true)
			{
				if (DateTime.Now >= endTime)
				{
					
					break;
				}
			}
			return s;
		}
		/*Simple web request for creating new task with .ContinueWith*/
		static Task<string> DownloadStringMethod1(Uri uri)
		{
			var client = new WebClient();
			var task = new Task<string>(() => client.DownloadString(uri));
			return task;
		}

		/*Simple web request for creating new asynchron task*/
		static async Task<string> DownloadStringMethod2(Uri uri)
		{
			var client = new WebClient();
			return await client.DownloadStringTaskAsync(uri);
		}

	}
}
