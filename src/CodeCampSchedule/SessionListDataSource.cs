
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.Drawing;

namespace CodeCampSchedule
{


	public class SessionListDataSource : UITableViewDataSource
	{

		private List<string> _items;
		private string _section1CellId;

		public SessionListDataSource (SessionListController controller)
		{
			_section1CellId = "cellid";
			_items = new List<string>(controller.Sessions);
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
				cell = new UITableViewCell(UITableViewCellStyle.Default, _section1CellId);
			}
				cell.TextLabel.Text = System.Web.HttpUtility.HtmlDecode(_items[indexPath.Row]);
			
		
			
			return cell;
		}
		
	}
	
	public class SessionTitleListCell: UITableViewCell{
		
		UIWebView webView;
		public SessionTitleListCell(string cellId):base(UITableViewCellStyle.Default, cellId)
		{
			webView = new UIWebView(new RectangleF(ContentView.Bounds.Location, ContentView.Bounds.Size));
			webView.BackgroundColor = UIColor.White;
			
			ContentView.AddSubview(webView);
			Accessory = UITableViewCellAccessory.DisclosureIndicator;
		}
		
		public void SetText(string text){
			webView.LoadHtmlString(text, new NSUrl("http://cnn.com"));
		}
		
	}
}
