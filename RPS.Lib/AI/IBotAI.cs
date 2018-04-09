using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Lib.AI
{
	public interface IBotAI 
	{
		Gesture GetGesture(Gesture playGesture);		
	}
}
