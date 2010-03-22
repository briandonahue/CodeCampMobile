
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace CodeCampSchedule
{


	public class SessionListDataSource : UITableViewDataSource
	{

		private List<string> _items;
		private string _section1CellId;

		public SessionListDataSource ()
		{
			_section1CellId = "cellid";
			_items = new List<string> { "Session 1", "Session 2", "Session 3", "Session 4", "Session 5" };
		}

		public override string TitleForHeader (UITableView tableView, int section)
		{
			return "Items";
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return _items.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			// For more information on why this is necessary, see the Apple docs
			var row = indexPath.Row;
			UITableViewCell cell = tableView.DequeueReusableCell (_section1CellId);
			
			if (cell == null) {
				// See the styles demo for different UITableViewCellAccessory
				cell = new UITableViewCell (UITableViewCellStyle.Default, _section1CellId);
				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			}
			
			cell.TextLabel.Text = _items[indexPath.Row];
			
			return cell;
		}
		
	}
}
