
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CodeCampSchedule
{


	public class SessionListTableDelegate: UITableViewDelegate
	{

		private SessionListController sessionListController;

		public SessionListTableDelegate (SessionListController controller)
		{
			sessionListController = controller;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
				sessionListController.NavigationController.PushViewController (new SessionDetails(), true);
		}
	}
}
