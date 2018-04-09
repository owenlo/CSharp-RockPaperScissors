using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Lib.AI
{
	public class RandomBot : IBotAI
	{
		private Random r = new Random();

		private int newGesture()
		{
			return r.Next(0, 3);
		}

		public Gesture GetGesture(Gesture playerGesture)
		{
			Gesture g = (Gesture)newGesture();
			return g;
		}
	}
}
