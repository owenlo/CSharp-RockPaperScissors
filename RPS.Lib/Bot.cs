using RPS.Lib.AI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Lib
{
	public class Bot : IBotAI
	{
		private IBotAI botAI;

		public Bot(IBotAI botAI)
		{
			this.botAI = botAI;
		}

		public Gesture GetGesture(Gesture playerGesture)
		{
			return botAI.GetGesture(playerGesture);
		}
	}
}
