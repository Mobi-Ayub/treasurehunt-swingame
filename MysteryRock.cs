using System;
using SwinGameSDK;

namespace PlanetaryRover
{
	public class MysteryRock: Specimen
	{
		public const int MaxRock = 10;
	
	// CONSTRUCTOR //
		public MysteryRock (): 
		base (Color.IndianRed)
		{
			viewable = true;
			drillStatus = true;
		}

	// METHODS //
		public Specimen CheckContent ()
		{
			int percentage = GetRandPercent ();

			Radar _radar = new Radar ();
			return _radar;

//			// gets solar
//			if (percentage <= 5)
//			{
//				Solar _solar = new Solar ();
//				return _solar;
//			} 
//
//			// gets potion
//			else if ((percentage > 5) && (percentage <= 30)) {
//				Potion _potion = new Potion ();
//				return _potion;
//			}
//		
//			// gets cursed rock
//			if ((percentage > 30) && (percentage <= 40))
//			{
//				CursedRock _cursedRock = new CursedRock ();
//				return _cursedRock;
//			}
//
//			// gets anpan
//			else if ((percentage > 40) && (percentage <= 60))
//			{
//				Anpan _anpan = new Anpan ();
//				return _anpan;
//			}
//
//			// gets battery
//			else if ((percentage > 60) && (percentage <= 80))
//			{
//				Battery _battery = new Battery ();
//				return _battery;
//			}
//
//			// gets radar
//			else if ((percentage > 80) && (percentage <= 85))
//			{
//				Radar _radar = new Radar ();
//				return _radar;
//			}
//
//			else
//			{
//				return null;
//			}
		}
	}
}

