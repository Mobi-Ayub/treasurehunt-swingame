using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace PlanetaryRover
{
	public class Player: Specimen
	{
		private int _lifepoints;						// Player's life points before death
		private string _name;							// Player's name
		private string _desc;							// Player's description
		private bool _drowsiness;						// Player's drowsiness - can be changed with Anpan
		private int _drowsinessCount;
		private List<Specimen> _inventory;				// Player's inventory
		private int _cash;

		private int _stepsTaken;
		private Device _activeDevice;					// Tells the player the current device s/he is holding
		private Drill _drill = new Drill ();				// Creates Radar: Device for player	
		private Radar _radar = new Radar ();
		private Solar _solar = new Solar ();
		//private int _stepsTaken;						// Counts the total amount of steps taken


	// CONSTRUCTOR //
		public Player (string name, string desc):
		base (Color.Red)
		{
			_lifepoints = 100;
			_name = name;
			_desc = desc;
			_inventory = new List<Specimen> ();
			_cash = 100;
			_drowsinessCount = 0;

			_activeDevice = _drill;
			viewable = true;
			drillStatus = true;
		}


	// METHODS //
		// Add all default devices to rover's inventory
		public void InitInventory()
		{
			_inventory.Add (_drill);
		}

		// Init Device
		public void InitDevice(Specimen device)
		{
			_inventory.Add (device);
		}

		// Changes the device s/he is currently holding
		public void ChangeActiveDevice (string input)
		{
			if (input == "d") {
				_activeDevice = _drill;
			} else if (input == "r") {
				_activeDevice = _radar;
			} else if (input == "s") {
				_activeDevice = _solar;
			}
		}

		// Makes the player move
		public void Move (string moveDirectionInput)
		{
			_lifepoints -= 1;
			if (_drowsinessCount == 0) {
				if (moveDirectionInput == "left") {
					ptX -= 1;
				} else if (moveDirectionInput == "right") {
					ptX += 1;
				} else if (moveDirectionInput == "up") {
					ptY -= 1;
				} else if (moveDirectionInput == "down") {
					ptY += 1;
				}
			} else {
				_drowsinessCount -= 1;
				if (moveDirectionInput == "left") {
					ptX += 1;
				} else if (moveDirectionInput == "right") {
					ptX -= 1;
				} else if (moveDirectionInput == "up") {
					ptY += 1;
				} else if (moveDirectionInput == "down") {
					ptY -= 1;
				}
			}
			_stepsTaken += 1;
		}

		public string ReadSpecimen (Specimen specimenOnPos) {
			if (specimenOnPos != null) {
				if ((ptX == specimenOnPos.ptX) && (ptY == specimenOnPos.ptY)) {
					return "This is a " + specimenOnPos.GetType ();
				}
			}
			return null;
		}
			
		// Heal the rover (Interact Item to trigger)
		public void UsePotion (List<Specimen> potionList, Potion potionOnPos)
		{
			const int PotionUnits = 10;

			if (potionOnPos != null)
			{
				Console.WriteLine (potionOnPos.drillStatus);
				if (potionOnPos.drillStatus == true) {
					potionOnPos.viewable = false;
			
					_lifepoints += PotionUnits;
					potionList.Remove (potionOnPos);
				}
			}
		}

		// Extract Rocks (Interact Item to trigger)
		public void ExtractRock (List<Specimen> specimenList, List<MysteryRock> rockList, MysteryRock rockOnPos)
		{
			if ((rockOnPos.ptX == ptX) && (rockOnPos.ptY == ptY)) {
				Specimen specimenFound = rockOnPos.CheckContent ();
				specimenList.Remove (rockOnPos);

				if ((specimenFound != null)) {
					specimenFound.ptX = rockOnPos.ptX;
					specimenFound.ptY = rockOnPos.ptY;
					// add new specimen on that same spot
					specimenList.Add (specimenFound);
					// remove rock on that same spot

					specimenFound.viewable = true;
					specimenFound.drillStatus = true;
				} 
			}
		}

		// Attaches bat to device and destroys the bat (Interact Item to trigger)
		public void AttachBat (List<Battery> batteryList, Battery batOnPos)
		{
			const int MaxBatUnits = 10;

			if (batOnPos != null) {
				if (batOnPos.drillStatus == true) {
					batOnPos.viewable = false;
			
					_activeDevice.BatUnits += (MaxBatUnits - _activeDevice.BatUnits);
				}
			}
		}
			
		// Drills item out of ground, makes object onGround
		public void Drill(Specimen specimen)
		{
			_drill.checkRisk ();

			_drill.devWearFactor += _drill.devDrainUnitsPerUse;
			specimen.drillStatus = true;
			_drill.devWearFactor += 5;
		}

		// Helps the rover scan while the radar is active
		public List<Specimen> Scan (List<Specimen> specimenList)
		{
			_radar.FindScanDepth (ptX, ptY);
			List<Specimen> ScanResults = new List<Specimen> ();
			_radar.BatUnits -= _radar.BatDrainUnits;

			foreach (Specimen specimen in specimenList)
			{
				if ((specimen.ptX >= _radar.scanPtXStart) && (specimen.ptX <= _radar.scanPtXEnd))
				{
					if ((specimen.ptY >= _radar.scanPtYStart) && (specimen.ptY <= _radar.scanPtYEnd))
					{
						ScanResults.Add (specimen);
					}
				}
			}
			return ScanResults;
		}

		// Adds one power to any device of the player's choice
		public void AddPower(Device chosenDevice)
		{
			Solar _solar = new Solar ();
			if ((_activeDevice == _solar) && (_solar.BatUnits >= _solar.BatDrainUnits))
			{
				_solar.BatUnits -= _solar.BatDrainUnits;
				chosenDevice.BatUnits += 1;
			}
		}
			
		public Solar solar
		{
			get
			{ return _solar; }
			set
			{ _solar = value; }
		}

		public Drill drill
		{
			get
			{ return _drill; }
			set
			{ _drill = value; }
		}

		public Radar radar
		{
			get
			{ return _radar; }
			set
			{ _radar = value; }
		}

		public int lifePoints
		{
			get
			{ return _lifepoints; }
			set
			{ _lifepoints = value; }
		}
			
		public List<Specimen> inventory {
			get
			{ return _inventory; }
		}

		public Device activeDevice {
			get
			{ return _activeDevice; }
			set
			{ _activeDevice = value; }
		}

		public bool Drowsiness {
			get
			{ return _drowsiness; }
			set
			{ _drowsiness = value; }
		}

		public int StepsTaken {
			get
			{ return _stepsTaken; }
			set
			{ _stepsTaken = value; }
		}

		public int drowsinessCount {
			get
			{ return _drowsinessCount; }
			set
			{ _drowsinessCount = value; }
		}

		public int cash {
			get
			{ return _cash; }
			set
			{ _cash = value; }
		}
	}
}

