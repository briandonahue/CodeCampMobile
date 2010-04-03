
using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using CodeCampSchedule.Core;
using CodeCampSchedule.Core.Data;

namespace CodeCampSchedule
{
	public class Application
	{
		static void Main (string[] args)
		{
			UIApplication.Main (args);
		}
	}

	// The name AppDelegate is referenced in the MainWindow.xib file.
	public partial class AppDelegate : UIApplicationDelegate
	{
		NavigationController navigationController;
		// This method is invoked when the application has loaded its UI and its ready to run
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// If you have defined a view, add it here:
			// window.AddSubview (navigationController.View);
			var alert = new UIAlertView{
				Title = "Update Schedule", 
				Message = "Would you like to get the latest schedule information?"};
			alert.Delegate = new UpdateDataAlertViewDelegate();
			
			alert.AddButton("No");
			alert.AddButton("Yes");
			alert.Show();
			
			navigationController = new NavigationController();
			window.AddSubview(navigationController.View);
			
			window.MakeKeyAndVisible ();
			
			return true;
		}

		// This method is required in iPhoneOS 3.0
		public override void OnActivated (UIApplication application)
		{
		}
	}
	
	public class UpdateDataAlertViewDelegate: UIAlertViewDelegate{
	
		public override void Clicked (UIAlertView alertview, int buttonIndex)
		{
			Console.WriteLine("clicked");
			if (buttonIndex != 0) {
				var client = new WebClient ();
				var data = client.DownloadData (new Uri ("http://codecamp.phillydotnet.org/2010-1/_layouts/listfeed.aspx?List={447CD038-3CF6-484F-9C0B-A1AE5D979519}"));
				
				var db = new Database ();
				var times = db.GetAvailableTimeSlots ();
				
				var extractor = new DataExtractor ();
				db.UpdateData (extractor.GetSessionData (times, new MemoryStream (data)));
			}
		}
		
		public override void Canceled (UIAlertView alertView)
		{
			Console.WriteLine("Canceled");
		}


	}
}
