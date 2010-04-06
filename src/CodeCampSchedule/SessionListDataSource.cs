
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.Drawing;
using CodeCampSchedule.Core.Data;
using System.Web;
using System.Drawing;
using System.Linq;

namespace CodeCampSchedule
{


	public class SessionListDataSource : UITableViewSource
	{

		private List<SessionCellData> _items;
		private string _section1CellId;
		SessionListController controller;
		UIFont font;

		public SessionListDataSource (SessionListController controller)
		{
			this.controller = controller;
			_section1CellId = "cellid";
			_items = new List<SessionCellData>(from s in controller.Sessions
				orderby s.Title
				select new SessionCellData { Title = HttpUtility.HtmlDecode (s.Title), Track = HttpUtility.HtmlDecode (s.Track) });
			font = UIFont.FromName ("Helvetica", 12f);
		}

		public override string TitleForHeader (UITableView tableView, int section)
		{
			return "Items";
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return _items.Count ();
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			
			// Get cached cell
			var cell = tableView.DequeueReusableCell (_section1CellId);
			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Default, _section1CellId);
			}
			
			var sessionData = _items[indexPath.Row];
			var view = cell.ViewWithTag (28) as SessionListItemView;
			if (view == null) {
				view = new SessionListItemView ();
				view.Tag = 28;
				RectangleF rect = new RectangleF(0, 0, 320, sessionData.CellSize.Height);
				view.Frame = rect;
				
				cell.ContentView.AddSubview (view);
			}
			
			view.Title.Frame = view.Frame;
			
			view.Title.Lines = 0;
			view.Title.LineBreakMode = UILineBreakMode.WordWrap;
			view.Title.Text = sessionData.Title;
			
			
			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var session = controller.Sessions.ElementAt (indexPath.Row);
			controller.NavigationController.PushViewController (new SessionDetailsController (session), true);
		}

		public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			var cellData = _items[indexPath.Row];
			if (cellData.CellSize.Height == 0) {
				cellData.TitleSize = tableView.StringSize (cellData.Title, font, new SizeF (237f, 1000f), UILineBreakMode.WordWrap);
				cellData.CellSize = new SizeF (cellData.TitleSize.Width, cellData.TitleSize.Height + 20);
			}
			
			return cellData.CellSize.Height;
			
		}
		
		
	}

	public class SessionListItemView : UIView
	{
		public UILabel Title { get; set; }

		public SessionListItemView ()
		{
			Title = new UILabel ();
			Title.Font= UIFont.FromName ("Helvetica", 12f);
			
			AddSubview (Title);
		}
	}

	public class SessionCellData
	{

		public string Title { get; set; }
		public string Track { get; set; }
		public SizeF TitleSize { get; set; }
		public SizeF CellSize { get; set; }
	}
}
