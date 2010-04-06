
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
		public IEnumerable<Session> Sessions{get; set;}
		SQLiteConnection db;
		
		public SessionListController (string sessionTime)
		{
			this.sessionTime = sessionTime;
		}
		
		public override void ViewDidLoad ()
		{
			// TODO: Better manage the db connection lifetime
			db = new DatabaseFactory().InitDb();
			var sessions = (from s in db.Table<Session>() select s);
			Sessions = (from s in sessions where s.Time.ToString("h:mm") == sessionTime select s).ToList();
			TableView.Source = new SessionListDataSource(this);
			base.ViewDidLoad ();
		}

	}
}
