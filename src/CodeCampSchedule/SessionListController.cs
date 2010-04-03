
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using CodeCampSchedule.Core;
using CodeCampSchedule.Core.Data;
using System.Linq;
using SQLite;

namespace CodeCampSchedule
{


	public class SessionListController: UITableViewController
	{

		string sessionTime;
		public IEnumerable<string> Sessions{get; set;}
		ISessionRepository sessionRepo;
		SQLiteConnection db;
		
		public SessionListController (string sessionTime)
		{
			this.sessionTime = sessionTime;
		}
		
		public override void ViewDidLoad ()
		{
			
			db = new DatabaseFactory().InitDb();
			var sessions = (from s in db.Table<Session>() select s);
			Sessions = (from s in sessions where s.Time.ToString("h:mm") == sessionTime select s.Title).ToList();
			TableView.DataSource = new SessionListDataSource(this);
			TableView.Delegate = new SessionListTableDelegate(this);
			base.ViewDidLoad ();
		}

	}
}
