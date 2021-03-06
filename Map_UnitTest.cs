using NUnit.Framework;
using System;

namespace PlanetaryRover
{
	[TestFixture ()]
	public class MapUnitTest
	{
		// CTRL + T to run Unit Test
		// Navigate to Successful & Failed Tests for results

		// Test that map initialises
		[Test ()]
		public void TestInitMap ()
		{
			Map _map = new Map ();
			_map.InitMap ();

			bool result = _map.grid [19][19];
			Assert.AreEqual (false, result);

			result = _map.grid [4][5];
			Assert.AreEqual (false, result);
		}

		// Test that batteries initalise
		[Test ()]
		public void TestInitBat ()
		{
			Map _map = new Map ();
			_map.InitMap ();
			_map.InitBat ();

			Assert.AreEqual(10, _map.SpecimenList.Count);
		}

		// Test that player initialises
		[Test ()]
		public void TestInitPlayer ()
		{
			Map _map = new Map ();
			_map.InitMap ();

			Assert.AreEqual(1, _map.SpecimenList.Count);
		}

		// Test that rocks initialise
		[Test ()]
		public void TestInitRocks ()
		{
			Map _map = new Map ();
			_map.InitMap ();
			_map.InitRocks ();		// adds 10

			Assert.AreEqual(11, _map.SpecimenList.Count);
		}

		// Test that motor initialises
		[Test ()]
		public void TestInitMotor ()
		{
			Map _map = new Map();
//			Motor _motor = _map.InitMotor ();

//			_map.SpecimenList.Add (_motor);

//			Assert.AreEqual (_map.SpecimenList[0], _motor);
		}
	}
}

