using System;
using SwinGameSDK;

namespace PlanetaryRover
{
	public class Specimen
	{
		private int _ptX, _ptY;					// determines the (x,y) of the specimen
		// private int _size;					// determines the size
		private Color _color;					// determines the colour of the block
		private bool _viewable;						// Finds out if an item can be seen on the surface
		private bool _drillStatus;					// Finds out if the item has been drilled out
		private bool _abstractItem;

		private static Random _random = new Random();		// generates random position number


	// CONSTRUCTOR //
		public Specimen (Color color)
		{
			_ptX = GetRandPosition();
			_ptY = GetRandPosition();
			_color = color;
			_viewable = false;
			_drillStatus = false;
			_abstractItem = false;
				// # things to implement # //
			//_size = size;
		}
		public Specimen(): this(Color.Red) {}


	// METHODS //
		// Generates Random position for specimen
		public int GetRandPosition()
		{
			// # QUESTION # seems to be a bit off
			// will draw one col less
			return _random.Next (1,20);
		}

		// Generates Random out of 100 for probability
		public int GetRandPercent()
		{
			return _random.Next (1, 99);
		}


	// PROPERTIES //
		public int ptX {
			get
			{ return _ptX; }
			set
			{ _ptX = value; }
		}

		public int ptY {
			get
			{ return _ptY; }
			set
			{ _ptY = value; }
		}

		public bool viewable {
			get
			{ return _viewable; }
			set
			{ _viewable = value; }
		}

		public bool drillStatus {
			get
			{ return _drillStatus; }
			set
			{ _drillStatus = value; }
		}

		public Color color {
			get
			{ return _color; }
		}

		public bool abstractItem {
			get 
			{ return _abstractItem; }
			set
			{ _abstractItem = value; }
		}
	}
}