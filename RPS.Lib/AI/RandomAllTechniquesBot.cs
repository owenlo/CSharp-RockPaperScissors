using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Lib.AI
{
	public class RandomAllTechniquesBot : IBotAI
	{
		private Random r;
		private DumbAsRockBot dumbBot;
		private ImpossibleBot impossBot;
		private MirrrorPlayerBot mirrorPlayer;
		private RandomBot randBot;

		private List<IBotAI> objectList;

		public RandomAllTechniquesBot()
		{
			r = new Random();

			objectList = new List<IBotAI>();

			objectList.Add(new DumbAsRockBot());
			objectList.Add(new ImpossibleBot());
			objectList.Add(new MirrrorPlayerBot());
			objectList.Add(new RandomBot());
		}

		public Gesture GetGesture(Gesture playGesture)
		{
			int i = r.Next(objectList.Count);
			return objectList[i].GetGesture(playGesture);
		}
	}
}
