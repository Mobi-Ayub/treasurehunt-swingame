using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace PlanetaryRover {

    public class GameMain
    {
        public static void Main()
        {
			// Create the map - Initialise grid
			// Create player
			Map _map = new Map ();

				// # things to implement # 
				// possible implementation of tutorial
			// Add player's inventory
			_map.rover1.InitInventory ();
	
            //Open the game window & start screen
            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
            //SwinGame.ShowSwinGameSplashScreen();
			SwinGame.ClearScreen(Color.White);


			SwinGame.DrawText ("Check console output for instructions.", Color.Blue, "Arial", 12, 50, 55);

			Console.WriteLine ("");
			Console.WriteLine ("You are the red dot. You have " + _map.rover1.lifePoints + " life points. ");
			Console.WriteLine ("Coloured blocks are things on the ground. You may pick them up.");
			Console.WriteLine ("You have a drill equipped by default. You use it to drill out hidden items.");
			Console.WriteLine ("You lose a lifepoint everytime you walk.");
			Console.WriteLine ("To do stuff, use 'E' key.");
			Console.WriteLine ("To check your stats, use 'C' key.");
			Console.WriteLine ("");


            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
			{
                SwinGame.ProcessEvents();
					// # things to implement #
					// only allow one specimen in every block, exceptions for player
				_map.InitMap ();

				// initialises default batteries and mysrocks on ground
				_map.InitBat ();
				_map.InitRocks ();

				// draws grid
				_map.InitDrawGrid ();
				_map.DrawSpecimensOnMap ();

				if (SwinGame.KeyTyped (KeyCode.CKey))
				{
					Console.WriteLine ("Equipped: " + _map.rover1.activeDevice + " with " + _map.rover1.activeDevice.BatUnits + " units");
						// # things to implement #
						// make inventory into list
					Console.WriteLine ("Inventory Count: " + _map.rover1.inventory.Count);
					Console.WriteLine ("Lifepoints: " + _map.rover1.lifePoints);
					Console.WriteLine ("");
				}

				// interacts with item
				if (SwinGame.KeyTyped (KeyCode.EKey))
				{
					// radar the thing - scans 10m of surroundings
					if ((_map.rover1.inventory.Contains(_map.rover1.radar)) && (_map.rover1.activeDevice == _map.rover1.radar) && (_map.rover1.radar.BatUnits >= _map.rover1.radar.BatDrainUnits)) {
						List<Specimen> scanResults = _map.rover1.Scan(_map.SpecimenList);
						foreach (Specimen s in scanResults) {
							if (s.GetType () != typeof(MysteryRock)) {
								s.viewable = true;
								s.drillStatus = false;
								_map.SpecimenList.Add (s);
							}
						}
						Console.WriteLine ("You have scanned your surroundings. Green blocks are locations that have a hidden item.");
						Console.WriteLine ("Use a drill to drill them out.");
						Console.WriteLine ("");
					}
						
					List<Specimen> specimensFound = new List<Specimen> ();

					// Finds the specimenList in the same location as the player
					foreach (Specimen specimen in _map.SpecimenList) {
						if ((specimen.ptX == _map.rover1.ptX) && (specimen.ptY == _map.rover1.ptY)) {
							specimensFound.Add(specimen);
						}
					}


					// do stuff to the specimen
					foreach (Specimen specimen in specimensFound)
					{
						// no need to drill the thing
						if (specimen.drillStatus == true) {

							if (specimen is MysteryRock) {
								// can be extracted, and may leave behind something
								//
								Console.WriteLine ("You found a rock!");
								MysteryRock rockOnPos = (MysteryRock)specimen;
								_map.rover1.ExtractRock (_map.SpecimenList, _map.RockList, rockOnPos);
								Console.WriteLine ("You have extracted the rock. Something might have fell out of it.");
								Console.WriteLine ("");

								// remove the rest of the junk 
								_map.RockList.Remove (rockOnPos);
								_map.SpecimenList.Remove (rockOnPos);
							} else if (specimen is Battery) {
								// can add power to current active device
								//
								Console.WriteLine ("You found a battery!");
								Battery batOnPos = (Battery)specimen;
								_map.rover1.AttachBat (_map.BatteryAccList, batOnPos);
								Console.WriteLine ("You have successfully added more battery into your " + _map.rover1.activeDevice + ". ");
								Console.WriteLine ("It now has " + _map.rover1.activeDevice.BatUnits + " battery!");
								Console.WriteLine ("");

								// remove the rest of the junk
								_map.BatteryAccList.Remove (batOnPos);
								_map.SpecimenList.Remove (batOnPos);
							} else if (specimen is Radar) {
								// finds radar
								//
								if (_map.rover1.inventory.Contains (_map.rover1.radar)) {
									Console.WriteLine ("You found a radar! But you already have one...");
									Console.WriteLine ("");
								} else {
									Console.WriteLine ("You found a radar! You can use it to scan for specimens 10 blocks in radius.");
									_map.rover1.InitDevice (specimen);
									Console.WriteLine ("Hit R to equip it.");
									Console.WriteLine ("Hit D to change back to Drill");
									Console.WriteLine ("");
								}

								// remove the rest of the junk
								_map.SpecimenList.Remove (specimen);
							} else if (specimen is Solar) {
								// finds solar
								//
								if (_map.rover1.inventory.Contains (_map.rover1.solar)) {
									Console.WriteLine ("You found a solar! But you already have one...");
									Console.WriteLine ("");
								} else {
									Console.WriteLine ("You found a solar! You can use it to store battery units");
									_map.rover1.InitDevice (specimen);
									Console.WriteLine ("Hit S to equip it.");
									Console.WriteLine ("Hit D to change back to Drill");
									Console.WriteLine ("");
								}

								// remove the rest of the junk
								_map.SpecimenList.Remove (specimen);
							} else if (specimen is Anpan) {
								// makes player walk the opposite direction
								Console.WriteLine ("A sudden sweetness overcomes you, and you are struggling to walk straight temporarily.");
								int stepsTakenBefore = _map.rover1.StepsTaken;
								Console.WriteLine ("");
								_map.rover1.drowsinessCount = 30;

								// remove the rest of the junk
								_map.SpecimenList.Remove (specimen);
							} else if (specimen is CursedRock) {
								// reduces lifespan of the player
								//
								Console.WriteLine ("This rock is cursed. It took away 5 life points.");
								Console.WriteLine ("");
								_map.rover1.lifePoints -= 5;

								// remove the rest of the junk
								_map.SpecimenList.Remove (specimen);
							} else if (specimen is Potion) {
								// heals lifepoints
								//
								_map.rover1.lifePoints = 100;
								Console.WriteLine("You have been healed. Your lifepoints is " + _map.rover1.lifePoints + ". ");
								Console.WriteLine ("");
							}
						}

						// drill the thing
						else if (specimen.drillStatus == false)
						{
							if ((_map.rover1.inventory.Contains (_map.rover1.drill)) && (_map.rover1.activeDevice == _map.rover1.drill)) {
								_map.rover1.Drill (specimen);
								Console.WriteLine ("You have drilled the ground.");
								Console.WriteLine ("");
							}
						}
						break;
					}
				}

				// radar
				if((_map.rover1.inventory.Contains(_map.rover1.radar)) && (SwinGame.KeyTyped(KeyCode.RKey)))
				{
					_map.rover1.ChangeActiveDevice ("r");
					Console.WriteLine ("You are now holding a radar.");
				} 

				// drill
				if((_map.rover1.inventory.Contains(_map.rover1.drill)) && (SwinGame.KeyTyped(KeyCode.DKey)))
				{
					_map.rover1.ChangeActiveDevice ("d");
					Console.WriteLine ("You are now holding a drill.");
				} 

//				// solar
				if((_map.rover1.inventory.Contains(_map.rover1.solar)) && (SwinGame.KeyTyped(KeyCode.SKey)))
				{
					_map.rover1.ChangeActiveDevice ("s");
					Console.WriteLine ("You are now holding a solar.");
				} 
					
				// Changes the player's heading direction
				if (SwinGame.KeyTyped (KeyCode.LeftKey)) {
					_map.rover1.Move ("left");
				} else if (SwinGame.KeyTyped (KeyCode.RightKey)) {
					_map.rover1.Move ("right");
				} else if (SwinGame.KeyTyped (KeyCode.UpKey)) {
					_map.rover1.Move ("up");
				} else if (SwinGame.KeyTyped (KeyCode.DownKey)) {
					_map.rover1.Move ("down");
				}

				//Draw onto the screen
                SwinGame.RefreshScreen(10);
            }
        }
    }
}