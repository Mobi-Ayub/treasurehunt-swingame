using NUnit.Framework;
using System;

namespace PlanetaryRover
{
	[TestFixture ()]
	public class MysteryRockUnitTest
	{
		// CTRL + T to run Unit Test
		// Navigate to Successful & Failed Tests for results

		// Test possibilities
		// Test completed
		[Test ()]
		public void TestCheckPossibilities ()
		{
			MysteryRock _mysteryRock = new MysteryRock ();
			int percentage = _mysteryRock.GetRandPercent ();

//			string ans = _mysteryRock.CheckContent (percentage);

			//Assert.AreEqual (percentage, ans);
		}
	}
}