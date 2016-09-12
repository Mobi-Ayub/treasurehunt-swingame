using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace PlanetaryRover
{
	[TestFixture ()]
	public class PlayerUnitTests
	{
		// CTRL + T to run Unit Test
		// Navigate to Successful & Failed Tests for results

		[Test ()]
		public void TestAddDefaultDevices ()
		{
			Player _rover = new Player ("Player 1", "A good player");
			_rover.InitInventory ();

//			Assert.Contains (_rover.motor, _rover.inventory);
//			Assert.Contains (_rover.radar, _rover.inventory);
		}

//		[Test ()]
//		public void TestDevicesBatCount ()
//		{
//			Player _rover = new Player ("Player 1", "A good player");
//			_rover.InitInventory ();
//
//			Assert.AreEqual (10, _rover.motor.BatUnits);
//		}
//
//		// Test Rover attaches Bat
//		[Test ()]
//		public void TestAttachBat ()
//		{
//			Map _map = new Map ();
//			_map.InitBat ();
//
//			Player _rover = new Player ("Player 1", "A good player");
//			_rover.InitInventory ();
//			_rover.ChangeActiveDevice ("m");
//			int orgUnits = _rover.motor.BatUnits;
//
//			// after some usage
//			_rover.motor.BatUnits -= 9;
//			// after i drill it out
//			_map.SpecimenAccessibleList[0].drillStatus = true;
//
//			// adding batteries
//			_rover.InteractSpecimen (_map.SpecimenAccessibleList, _map.SpecimenAccessibleList[0]);
//			Assert.AreEqual (10, _rover.motor.BatUnits);
//		}			

		// my battery is not destroyed within AttachBat
		[Test ()]
		public void TestAttachBatDestroysBat ()
		{
			Map _map = new Map ();
			_map.InitBat ();

			Player _rover = new Player ("Player 1", "A good player");
			_rover.InitInventory ();
			_rover.ChangeActiveDevice ("m");

			// after i drill it out
			_map.BatteryAccList[0].drillStatus = true;

			// adding batteries
			Battery _bat = new Battery();
			int orgSpecimenAccessibleListCount = _map.BatteryAccList.Count;
			_rover.AttachBat (_map.BatteryAccList, _map.BatteryAccList[0]);

			Assert.AreEqual (orgSpecimenAccessibleListCount - 1, _map.BatteryAccList.Count);
		}	

		// makes rover move
		[Test ()]
		public void TestRoverMove ()
		{
			Player _rover = new Player ("Player 1", "A good player");
			int orgPt = _rover.ptX;
			_rover.ChangeActiveDevice ("m");
			_rover.Move ("left");
			Assert.AreEqual(orgPt - 1, _rover.ptX);
		}

//		[Test ()]
//		public void TestRoverAddPower ()
//		{
//			Player _rover = new Player ("Player 1", "A good player");
//			_rover.ChangeActiveDevice ("s");
//			int orgBatUnits = _rover.motor.BatUnits;
//				
//			_rover.AddPower (_rover.motor);
//			Assert.AreEqual(orgBatUnits + 1, _rover.motor.BatUnits);
//		}
//
//		[Test ()]
//		public void TestRoverAddPowerSolarReducesPower ()
//		{
//			Player _rover = new Player ("Player 1", "A good player");
//			_rover.ChangeActiveDevice ("s");
//			int orgBatUnits = _rover.solar.BatUnits;
//
//			_rover.AddPower (_rover.motor);
//			Assert.AreEqual(orgBatUnits - 1, _rover.solar.BatUnits);
//		}
			
//		[Test ()]
//		public void TestRoverScan ()
//		{
//			Player _rover = new Player ("Player 1", "A good player");
//			_rover.ptX = 10;
//			_rover.ptY = 10;
//			_rover.ChangeActiveDevice ("r");
//
//			Specimen _spec1 = new Specimen ();
//			_spec1.ptX = 11;
//			_spec1.ptY = 10;
//
//			Specimen _spec2 = new Specimen ();
//			_spec2.ptX = 50;
//			_spec2.ptY = 5;
//
//			List<Specimen> specimenList = new List<Specimen> ();
//			specimenList.Add (_spec1);
//			specimenList.Add (_spec2);
//
//			Console.WriteLine ("Specimen[0]'s location: " + specimenList [0].ptX + ", " + specimenList[0].ptY);
//			Console.WriteLine ("Specimen[1]'s location: " + specimenList [1].ptX + ", " + specimenList[1].ptY);
//
//
//			Assert.AreEqual(1, _rover.Scan (specimenList).Count);
//		}

//		[Test ()]
//		public void TestChangeActiveDevice ()
//		{
//			Player _rover = new Player ("Player 1", "A good player");
//			int orgPt = _rover.ptX;
//			_rover.ChangeActiveDevice ("m");
//			Assert.AreEqual(_rover.motor, _rover.activeDevice);
//			_rover.ChangeActiveDevice ("r");
//			Assert.AreEqual(_rover.radar, _rover.activeDevice);
//			_rover.ChangeActiveDevice ("d");
//			Assert.AreEqual(_rover.drill, _rover.activeDevice);
//		}

		[Test ()]
		public void TestReadSpecimen ()
		{
			Radar _radar = new Radar ();
			Player _rover = new Player ("Player 1", "A good player");

			_rover.ptX = 10;
			_rover.ptY = 10;
			_radar.ptX = _rover.ptX;
			_radar.ptY = _rover.ptY;

			Assert.AreEqual("This is a PlanetaryRover.Radar", _rover.ReadSpecimen (_radar));
		}

		[Test ()]
		public void TestRoverDrill ()
		{
			Player _rover = new Player ("Player 1", "A good player");
			int orgPt = _rover.ptX;
			_rover.ptX = 10;
			_rover.ptY = 10;
			int org = _rover.drill.devWearFactor;
			_rover.ChangeActiveDevice ("d");
			Assert.AreEqual(_rover.drill, _rover.activeDevice);
			Specimen _spec1 = new Specimen ();
			List<Specimen> _specimenList = new List<Specimen> ();
			_specimenList.Add (_spec1);
			_spec1.ptX = 10;
			_spec1.ptY = 10;
			_rover.Drill (_spec1);
			Assert.AreEqual(org + 10, _rover.drill.devWearFactor);
		}
	
		[Test ()]
		public void TestExtractRock()
		{
			Player _rover1 = new Player ("Player 1", "A good player");
			_rover1.ptX = 10;
			_rover1.ptY = 10;
			MysteryRock rock1 = new MysteryRock ();
			rock1.ptX = 10;
			rock1.ptY = 10;

			List<Specimen> specimenList = new List<Specimen> ();
			List<MysteryRock> rockList = new List<MysteryRock> ();
			rockList.Add (rock1);
			specimenList.Add (rock1);
			int orgSpecimenListCount = specimenList.Count;
			_rover1.ExtractRock (specimenList, rockList, rock1);

			//might not work if null is randomised, but that is also correct
			Assert.AreEqual (orgSpecimenListCount, specimenList.Count);

		}

//		[Test ()]
//		public void TestBatDrains ()
//		{
//			Player _rover = new Player ("Player 1", "A good player");
//			Map _map = new Map ();
//
//			int orgPt = _rover.radar.BatUnits;
//			_rover.ChangeActiveDevice ("r");
//			_rover.Scan (_map.SpecimenList);
//			Assert.AreEqual(orgPt - 4, _rover.radar.BatUnits);
//		}


	}
}

