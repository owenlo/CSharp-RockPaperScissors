using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Lib
{
	public interface IGame
	{
		RockPaperScissors PlaySinglePlayerGame(Gesture player1Gesture);

		RockPaperScissors PlayMultiplayerGame(Gesture player1Gesture, Gesture player2Gesture);

		Gesture Player1Gesture
		{
			get;		
		}

		Gesture Player2Gesture
		{
			get;		
		}

		Result Player1Result
		{
			get;	
		}

		Result Player2Result
		{
			get;
		}
	}
}
