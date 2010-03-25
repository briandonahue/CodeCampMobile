
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CodeCampSchedule
{


	public class SessionDetailsController: UITableViewController
	{
		public SessionDetailsController():base(UITableViewStyle.Grouped){}
		
		public override void ViewDidLoad ()
		{
			TableView.DataSource = new SessionDetailsDataSource();
			
			base.ViewDidLoad ();
		}

	}
}
