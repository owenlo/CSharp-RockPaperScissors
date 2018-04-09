using RPS.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Test.MockObjects
{
	class MockRockPaperScissors : IGame
	{
		public Gesture Player1Gesture
		{
			get;
			set;
		}

		public Gesture Player2Gesture
		{
			get;
			set;
		}

		public Result Player1Result
		{
			get;
			set;
		}

		public Result Player2Result
		{
			get;
			set;
		}

		public RockPaperScissors PlaySinglePlayerGame(Gesture player1Gesture)
		{
			throw new NotImplementedException();
		}

		public RockPaperScissors PlayMultiplayerGame(Gesture player1Gesture, Gesture player2Gesture)
		{
			throw new NotImplementedException();
		}
	}
}
