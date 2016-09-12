using System;
using SwinGameSDK;

namespace PlanetaryRover
{
	public abstract class Device: Specimen
	{
		private int _batUnits;			// Finds out the current battery count of device
		private int _batDrainUnits;		// Finds out the drain unit per us

	// CONSTRUCTOR //
		public Device (Color color):
		base(color)
		{
			_batUnits = 99999;
			_batDrainUnits = 0;
			viewable = false;
		}

	// METHODS //
		// public interface void Draw() {
		//public abstract void Extract()

	// PROPERTY //
		public int BatUnits
		{
			get
			{ return _batUnits; }
			set
			{ _batUnits = value; }
		}

		public int BatDrainUnits
		{
			get
			{ return _batDrainUnits; }
			set
			{ _batDrainUnits = value; }
		}
	}
}

