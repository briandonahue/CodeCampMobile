
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace CodeCampSchedule
{


	public class SessionListController: UITableViewController
	{

		string sessionTime;
		IEnumerable<string> sessions;
		ISessionRepository sessionRepo;
		
		public SessionListController (string sessionTime)
		{
			this.sessionTime = sessionTime;
			sessionRepo = new StubSessionRepo();
		}
		
		public override void ViewWillAppear (bool animated)
		{
			TableView.DataSource = new SessionListDataSource();
			TableView.Delegate = new SessionListTableDelegate(this);
//			sessions = sessionRepo.GetSessionsForTime(sessionTime); 
			base.ViewWillAppear (animated);
		}

	}
}
