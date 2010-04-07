
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.Drawing;
using CodeCampSchedule.Core.Data;
using System.Web;
using System.Linq;

namespace CodeCampSchedule
{


	public class SessionListDataSource : UITableViewSource
	{

		private List<SessionListItemView> _items;
		private string _section1CellId;
		SessionListController controller;
		UIFont titleFont;
		UIFont trackFont;

		public SessionListDataSource (SessionListController controller)
		{
			this.controller = controller;
			_section1CellId = "cellid";
			_items = new List<SessionListItemView>(from s in controller.Sessions
				orderby s.Title
				select new SessionListItemView{ Title = HttpUtility.HtmlDecode (s.Title), Track = HttpUtility.HtmlDecode (s.Track) });
		}

		public override string TitleForHeader (UITableView tableView, int section)
		{
			return controller.SessionTime;
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
				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			}
			
			var sessionData = _items[indexPath.Row];
			var view = cell.ViewWithTag (28) as SessionListItemView;
			if (view == null) {
				view = new SessionListItemView ();
				view.Tag = 28;
				cell.Frame = new RectangleF(0, 0, 320, sessionData.CellSize);
				RectangleF rect = new RectangleF(15, 0, 275, sessionData.CellSize);
				view.Frame = rect;
				
				cell.ContentView.AddSubview (view);
			}
			
			view.Title = sessionData.Title;
			view.Track = sessionData.Track;
			
	
			
			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{	
			var session = controller.Sessions.ElementAt(indexPath.Row);
			controller.NavigationController.PushViewController (new SessionDetailsController (session), true);
		}

		public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			var cellData = _items[indexPath.Row];
			
			return cellData.CellSize;
			
		}
		
		
	}

	public class SessionListItemView : UIView
	{
		public string Title { 
			get { return titleView.Text ?? string.Empty;	 } 
			set { 
				titleView.Text = value; 
				SetLabelHeights();
			}
		}

		public string Track { 
			get { return trackView.Text ?? string.Empty; }
			set { 
				trackView.Text = value; 
				SetLabelHeights();
			}
		}

		void SetLabelHeights ()
		{
			var stringSize = StringSize (Track, trackFont, new SizeF (275f, 1000f), UILineBreakMode.WordWrap);
			trackView.Frame = new RectangleF(0, 10, 275f, stringSize.Height);
			stringSize = StringSize (Title, titleFont, new SizeF (275f, 1000f), UILineBreakMode.WordWrap);
			titleView.Frame = new RectangleF(0, trackView.Frame.Height + 10, 275f, stringSize.Height);
		}

		
		public float CellSize { 
			get{
				return trackView.Frame.Height + titleView.Frame.Height +20;
			}
		}

		UILabel titleView;
		UILabel trackView;
		UIFont titleFont = UIFont.FromName ("Helvetica", 14f);
		UIFont trackFont = UIFont.FromName ("Helvetica", 11f);
		public SessionListItemView ()
		{
			titleView = new UILabel ();
			trackView = new UILabel();
			titleView.Font = titleFont;
			titleView.Lines = 0;
			titleView.LineBreakMode = UILineBreakMode.WordWrap;
			
			trackView.Font = trackFont;
			trackView.Lines = 1;
			trackView.LineBreakMode = UILineBreakMode.WordWrap;
			trackView.Text = Track;
			trackView.TextColor = UIColor.Gray;
			
		
			
			AddSubview (titleView);
			AddSubview (trackView);
		}
	}

}
