
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace CodeCampSchedule
{


	public class SessionDetailsDataSource: UITableViewDataSource
	{

		IList<SessionSectionData> sectionData;
		public SessionDetailsDataSource ()
		{
			var cellId = "section1";
			sectionData = new List<SessionSectionData>{
				new SessionSectionData(cellId){
					Title = "Session",
					Data = new List<UITableViewCell>
					{
						new SessionTitleCell("Session Name Is Very Long", cellId),
						new UITableViewCell(UITableViewCellStyle.Default, cellId),
						new SessionTimeCell("8:30 AM", "Room 141", cellId)}
				}
			};
			
		}
		
		public override string TitleForHeader (UITableView tableView, int section)
		{
			return sectionData[section].Title;
		}
		
		public override int RowsInSection (UITableView tableview, int section)
		{
			return sectionData[section].Data.Count;
		}
		
		public override int NumberOfSections (UITableView tableView)
		{
			return sectionData.Count;
		}
		
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var section = sectionData[indexPath.Section];
			var cellId = section.CellId;
			var row = section.Data[indexPath.Row];
			
			var cell = tableView.DequeueReusableCell(cellId);
			if(cell == null)
			{
				
				cell = row;
			}
			
			return cell;
		}

	}
	
	class SessionSectionData
	{
		public string Title {get; set;}
		public string CellId {get;set;}
		public IList<UITableViewCell> Data { get; set; }
		
		public SessionSectionData(string cellId)
		{
			CellId = cellId;
		}
	}		
	
	class SessionTitleCell: UITableViewCell
	{
		
		public SessionTitleCell(string title, string cellId):base(UITableViewCellStyle.Default, cellId)
		{
			TextLabel.Text = title;			
		}
	}
	
	class SessionTimeCell: UITableViewCell
	{
		public SessionTimeCell(string time, string room, string cellId):base(UITableViewCellStyle.Subtitle, cellId)
		{
			TextLabel.Text = time;
			this.DetailTextLabel.Text = room;
		}
	}
}
