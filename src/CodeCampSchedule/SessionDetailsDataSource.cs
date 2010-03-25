
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
			sectionData = new List<SessionSectionData>{
				new SessionSectionData("section1"){
					Title = "Session",
					Data = new List<string>{"Session Name", "Speaker Name", "room", "time"}
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
				cell = new UITableViewCell(UITableViewCellStyle.Default, cellId);
				cell.TextLabel.Text = row;
			}
			
			return cell;
		}

	}
	
	class SessionSectionData
	{
		public string Title {get; set;}
		public string CellId {get;set;}
		public IList<string> Data { get; set; }
		
		public SessionSectionData(string cellId)
		{
			CellId = cellId;
		}
	}		
}
