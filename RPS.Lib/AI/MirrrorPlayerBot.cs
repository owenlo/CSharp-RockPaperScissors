using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Lib.AI
{
	public class MirrrorPlayerBot : IBotAI
	{
		private Random r = new Random();
		private Gesture[] gestureSet;
		private int count;

		public MirrrorPlayerBot()
		{
			gestureSet = new Gesture[2];
			gestureSet[0] = Gesture.None;
			count = -1;
		}

		private int newGesture()
		{
			return r.Next(0, 3);
		}

		public Gesture GetGesture(Gesture playGesture)
		{
			count++;

			if (gestureSet[0] == Gesture.None)
			{
				gestureSet[0] = playGesture;
				return (Gesture)newGesture();
			}
			else
			{
				if (count % 2 == 0)
				{
					gestureSet[1] = playGesture;
					return gestureSet[0];
				}
				else
				{
					gestureSet[0] = playGesture;
					return gestureSet[1];
				}
			}
		}
	}
}
