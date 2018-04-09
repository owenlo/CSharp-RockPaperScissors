using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Lib.AI
{
	public class DumbAsRockBot : IBotAI
	{
		public Gesture GetGesture(Gesture playerGesture)
		{
			return Gesture.Rock;
		}
	}
}
