using System;
using SwinGameSDK;

namespace PlanetaryRover
{
	public class Radar: Device
	{
		private int _scanPtXStart, _scanPtXEnd;
		private int _scanPtYStart, _scanPtYEnd;

	// CONSTRUCTOR //
		public Radar () :
		base (Color.CadetBlue)
		{
			BatDrainUnits = 4;
		}
	
	// METHODS //

		// finds the depth of scan to execute
		public void FindScanDepth(int ptX, int ptY)
		{
			int scanAreaDepth = 5;

			_scanPtXStart = ptX - scanAreaDepth; 
			_scanPtXEnd = ptX + scanAreaDepth;
			_scanPtYStart = ptY - scanAreaDepth;
			_scanPtYEnd = ptY + scanAreaDepth;
		}

	// PROPERTIES //

		public int scanPtXStart
		{
			get
			{ return _scanPtXStart; }
		}

		public int scanPtXEnd
		{
			get
			{ return _scanPtXEnd; }
		}

		public int scanPtYStart
		{
			get
			{ return _scanPtYStart; }
		}

		public int scanPtYEnd
		{
			get
			{ return _scanPtYEnd; }
		}
	}
}

