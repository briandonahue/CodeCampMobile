
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CodeCampSchedule
{


	public class HomeTableDelegate : UITableViewDelegate
	{

		private HomeController homeController;

		public HomeTableDelegate (HomeController controller)
		{
			homeController = controller;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var selectedCell = tableView.DataSource.GetCell(tableView, indexPath);
			var cellText = selectedCell.TextLabel.Text;
			
			var nextController = new SessionListController(cellText);
			
	
			if (nextController != null)
				homeController.NavigationController.PushViewController (nextController, true);
		}
	}
}
