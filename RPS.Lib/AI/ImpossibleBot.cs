using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Lib.AI
{
	public class ImpossibleBot : IBotAI
	{
		public Gesture GetGesture(Gesture playGesture)
		{
			if (playGesture == Gesture.Paper)
			{
				return Gesture.Scissors;
			}

			if (playGesture == Gesture.Rock)
			{
				return Gesture.Paper;
			}

			if (playGesture == Gesture.Scissors)
			{
				return Gesture.Rock;
			}

			return Gesture.None;
		}

	}
}
