using System;
using NUnit.Framework;

namespace Task3
{
	[TestFixture]
	public class Tests
	{
		[Test]
		public void SimpleTest ()
		{
			Assert.IsTrue(1 == 1);
		}

		[Test]
		public void Test_Sword_Arguments()
		{
		var x = new Sword ("Gorgei", 1867, 120, "Kevin Nagy");
			Assert.IsTrue (x.Brand == "Gorgei" && x.ManufactureDate == 1867 && x.Lenght == 120.00);
		}

		[Test]
		public void Test_Sword_Brand_NotEmpty()
		{
			Assert.Catch(() =>
			{
				var x = new Sword("", 1867, 120, "Kevin Nagy");
			});
		}

		[Test]
		public void Test_Sword_MacufactureDate_NotNeg ()
			{
				Assert.Catch (() => {
					var x = new Sword ("Gorgei", -1867, 120, "Kevin Nagy");
				});
			}

		[Test]
		public void Test_Sword_ChangeOwner()
		{
			var x = new Sword("Gorgei", 1867, 120, "Kevin Nagy");
			x.UpdateOwner("MIA");
			Assert.IsTrue(x.Owner == "MIA");
		}



		[Test]
		public void Test_Flintlock_Arguments()
		{
			var x = new Flintlock("Colt", 1820, 7.5, "John Doe");
			Assert.IsTrue(x.Brand == "Colt" && x.ManufactureDate == 1820 && x.Calibre == 7.5);
		}

		[Test]
		public void Test_Flintlock_Brand_NotEmpty()
		{
			Assert.Catch(() =>
			{
				var x = new Flintlock("", 1820, 7.5, "John Doe");
			});
		}

		[Test]
		public void Test_Flintlock_MacufactureDate_NotNeg()
		{
			Assert.Catch(() =>
			{
				var x = new Flintlock("Colt", -1820, 7.5, "John Doe");
			});
		}

		[Test]
		public void Test_Flintlock_ChangeOwner()
		{
			var x = new Flintlock("Colt", 1820, 7.5, "John Doe");
			x.UpdateOwner("MIA");
			Assert.IsTrue(x.Owner == "MIA");
		}

	}
}

