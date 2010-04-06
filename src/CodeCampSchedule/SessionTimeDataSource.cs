
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using CodeCampSchedule.Core;
using CodeCampSchedule.Core.Data;
using SQLite;
using System.Linq;

namespace CodeCampSchedule
{


	public class SessionTimeDataSource : UITableViewDataSource
	{
		private List<string> items;
		private string section1CellId;

		public SessionTimeDataSource (SQLiteConnection db)
		{
			items = new List<string>(from i in db.Table<TimeSlot>()
					orderby i.Time select i.Time.ToString("h:mm"));
					
			section1CellId = "item_id";
			
			
		}

		public override string TitleForHeader (UITableView tableView, int section)
		{
			return "Schedule";
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return items.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			// For more information on why this is necessary, see the Apple docs
			UITableViewCell cell = tableView.DequeueReusableCell (section1CellId);
			
			if (cell == null) {
				// See the styles demo for different UITableViewCellAccessory
				cell = new UITableViewCell (UITableViewCellStyle.Default, section1CellId);
				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			}
			
			cell.TextLabel.Text = items[indexPath.Row];
			
			return cell;
		}
		
	}
}
