using System;

namespace Task3
{
	public interface Weapon
	{

		string Brand { get; }

		int ManufactureDate { get; }

		string Owner { get; set; }

		void UpdateOwner(string newOwner);
	}
}

