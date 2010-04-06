
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using CodeCampSchedule.Core.Data;

namespace CodeCampSchedule
{


	public class SessionDetailsController: UITableViewController
	{
		public Session Session{get; set;}
		public SessionDetailsController(Session session):base(UITableViewStyle.Grouped)
		{
			Session = session;	
		}
		
		public override void ViewDidLoad ()
		{
			TableView.DataSource = new SessionDetailsDataSource(Session);
			
			base.ViewDidLoad ();
		}

	}
}
