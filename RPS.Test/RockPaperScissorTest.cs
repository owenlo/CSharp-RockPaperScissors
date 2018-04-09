using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPS.Lib;
using System.Diagnostics;
using RPS.Test.MockObjects;

namespace RPS.Test
{
	[TestClass]
	public class RockPaperScissorTest
	{
		[TestMethod]		
		public void WinTest()
		{
			RockPaperScissors rps = new RockPaperScissors();
			MockRockPaperScissors mockRPS = new MockRockPaperScissors()
			{
				Player1Gesture = Gesture.Scissors,
				Player2Gesture = Gesture.Paper,
				Player1Result = Result.Win,
				Player2Result = Result.Lose
			};

			var expectedResult = mockRPS;
			var actualResult = rps.PlayMultiplayerGame(Gesture.Scissors, Gesture.Paper);

			Assert.AreEqual(expectedResult.Player1Result, actualResult.Player1Result);
			Assert.AreEqual(expectedResult.Player2Result, actualResult.Player2Result);
		}

		[TestMethod]
		public void LoseTest()
		{
			RockPaperScissors rps = new RockPaperScissors();
			MockRockPaperScissors mockRPS = new MockRockPaperScissors()
			{
				Player1Gesture = Gesture.Scissors,
				Player2Gesture = Gesture.Rock,
				Player1Result = Result.Lose,
				Player2Result = Result.Win
			};

			var expectedResult = mockRPS;
			var actualResult = rps.PlayMultiplayerGame(Gesture.Scissors, Gesture.Rock);

			Assert.AreEqual(expectedResult.Player1Result, actualResult.Player1Result);
			Assert.AreEqual(expectedResult.Player2Result, actualResult.Player2Result);
		}

		[TestMethod]
		public void DrawTest()
		{
			RockPaperScissors rps = new RockPaperScissors();
			MockRockPaperScissors mockRPS = new MockRockPaperScissors()
			{
				Player1Gesture = Gesture.Paper,
				Player2Gesture = Gesture.Paper,
				Player1Result = Result.Draw,
				Player2Result = Result.Draw
			};

			var expectedResult = mockRPS;
			var actualResult = rps.PlayMultiplayerGame(Gesture.Paper, Gesture.Paper);

			Assert.AreEqual(expectedResult.Player1Result, actualResult.Player1Result);
			Assert.AreEqual(expectedResult.Player2Result, actualResult.Player2Result);
		}
	}
}

