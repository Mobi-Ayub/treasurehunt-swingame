using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace PlanetaryRover
{
	public class Map
	{
	// CONSTANTS //
		public readonly int MaxColRow = 20;			// max columns and rows on grid
		public readonly int CellWidth = 20;			// the size of each cell
		public readonly int CellGap = 1;			// the gap between each cell
		public readonly int GridPositionXY = 50;	// the position of grid away from (0,0)
	
		Player _rover1 = new Player ("Player 1", "A good player");			// creates new Rover 1
	// #implementation# this player will interrupt player 1  //s
//		Player _player2 = new Player ("Player 2", "A bad player");			// creates new Rover 2
		private bool[][] _grid;							// the grid
		private int _col, _row;							// the columns and rows for the grid
		private int DrawMapY, DrawMapX;					// decides where the item will be drawn
		private int MaxBat = 10;
		private int MaxRockCount = 10;

		private	List<Specimen> _specimenList = new List<Specimen> ();		// collects all the specimens on the map				
		private	List<Battery> _batteryAccList = new List<Battery> ();		// collects all the batteries on the map
		private List<MysteryRock> _rockList = new List<MysteryRock> ();		// collects all the rocks on the map

		Random _randRockNo = new Random ();


	// CONSTRUCTOR //
		public Map ()
		{
			_col = 0;
			_row = 0;
		}


	// METHODS //

		// Initialises each grid[i][j]
		public void InitMap ()
		{
			_grid = new bool[MaxColRow][];

			for(int j = 0; j < MaxColRow; j++)
			{
				_grid [j] = new bool[MaxColRow];

				for (int i = 0; i < MaxColRow; i++)
				{
					_grid [j][i] = false;
				}
			}
		}

		// Draws grid onto the Map
		public void InitDrawGrid()
		{
			foreach (bool[] row in _grid)
			{
				_row += 1;
				DrawMapY = _row * (CellWidth + CellGap) + GridPositionXY;

				foreach (bool col in row)
				{
					DrawMapX = _col * (CellWidth + CellGap) + GridPositionXY;
					_col += 1;

					SwinGame.FillRectangle (Color.Black, DrawMapX, DrawMapY, CellWidth, CellWidth);					
				}
				_col = 0;
			}
			_row = 0;
		}

		// Init Rocks on the screen
		public void InitRocks ()
		{
			while (_rockList.Count < MaxRockCount)
			{
				MysteryRock mysteryRock = new MysteryRock ();

				_rockList.Add (mysteryRock);
				_specimenList.Add (mysteryRock);
			}
		}

		// Init Batteries to (be prepared to) draw to screen//
		public void InitBat()
		{
			while (_batteryAccList.Count < MaxBat)
			{
				Battery battery = new Battery ();

				_batteryAccList.Add (battery);
				_specimenList.Add (battery);
			}
		}

		// Draws all specimens put in specimenList onto screen
		public void DrawSpecimensOnMap()
		{
			foreach (Specimen specimen in _specimenList)
			{
				DrawMapX = specimen.ptX * (CellWidth + CellGap) + GridPositionXY;
				DrawMapY = specimen.ptY * (CellWidth + CellGap) + GridPositionXY;

				if (specimen.viewable == true) {
					SwinGame.FillRectangle (Color.Green, DrawMapX, DrawMapY, CellWidth, CellWidth);					

					if (specimen.drillStatus == true) {
						SwinGame.FillRectangle (specimen.color, DrawMapX, DrawMapY, CellWidth, CellWidth);		
					}
				}
			}

			DrawMapX = rover1.ptX * (CellWidth + CellGap) + GridPositionXY;
			DrawMapY = rover1.ptY * (CellWidth + CellGap) + GridPositionXY;

			SwinGame.FillRectangle (rover1.color, DrawMapX, DrawMapY, CellWidth, CellWidth);
		}	
			
	// PROPERTIES //
		public bool[][] grid {
			get
			{ return _grid; }
		}

		public List<Specimen> SpecimenList {
			get 
			{ return _specimenList; }
		}

		public List<Battery> BatteryAccList {
			get 
			{ return _batteryAccList; }
		}

		public List<MysteryRock> RockList {
			get
			{ return _rockList; }
		}

		public Player rover1 {
			get 
			{ return _rover1; }
		}
	}
}

