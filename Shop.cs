using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace PlanetaryRover
{
	public class Shop: Specimen
	{
	// CONSTRUCTOR //
		List<Specimen> _sellList;
		public int _size;

		public Shop (string name, string desc):
		base (Color.Beige)
		{
			_size = 4;
		}

	// METHODS //
		public void InitSellList()
		{
			Motor _motor = new Motor ();
			Solar _solar = new Solar ();

			_sellList.Add (_motor);
			_sellList.Add (_solar);
//			_sellList.Add (_potion);
		}

		public void DisplaySellList()
		{
		}

		public void RemovePurchasedItems(){}
	
	// PROPERTIES //
		public int size {
			get
			{ return _size; }
			set 
			{ _size = value; }
		}
	}

}

