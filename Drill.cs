using System;
using SwinGameSDK;

namespace PlanetaryRover
{
	public class Drill: Device
	{
		public const int _devDrainUnitsPerUse = 5;

		private int _devWearFactor;						// find out the wear factor of device
		private bool _operateStatus;					// find out if the device is operating
			// #things to implement # //
//		private int _previousStepsTaken;

	
	// CONSTRUCTOR //

		public Drill () :
		base (Color.Blue)
		{
			_devWearFactor = 0;
			_operateStatus = true;
			BatUnits = 10;
		}


	// METHODS //

		public void checkRisk()
		{
			if (_devWearFactor >= 100) {
				_devWearFactor = 100;

				Random randNum = new Random ();
				int _randNum = randNum.Next (9);

				if (_randNum <= 1) {
					_operateStatus = false;
				} else {
					_operateStatus = true;
				}
			}
		}


	// PROPERTY //
		public int devDrainUnitsPerUse {
			get
			{ return _devDrainUnitsPerUse; }
		}

		public int devWearFactor {
			get
			{ return _devWearFactor; }
			set
			{ _devWearFactor = value; }
		}

		public bool operateStatus {
			get
			{ return _operateStatus; }
			set
			{ _operateStatus = value; }
		}
	}
}

