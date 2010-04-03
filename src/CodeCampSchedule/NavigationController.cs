
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Net;
using CodeCampSchedule.Core;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.ComponentModel;

namespace CodeCampSchedule
{

	public class NavigationController : UINavigationController
	{
		HomeController homeController;

		public override void ViewDidLoad ()
		{
			
				
			homeController = new HomeController ();
			PushViewController (homeController, true);
			base.ViewDidLoad ();
		}
	}
}
