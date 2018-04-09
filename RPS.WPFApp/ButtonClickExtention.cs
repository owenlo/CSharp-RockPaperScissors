﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RPS.WPFApp
{
	public static class ButtonClickExtention
	{
		public static void PerformClick(this Button btn)
		{
			btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
		}
	}
}
