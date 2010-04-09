
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using CodeCampSchedule.Core.Data;
using System.Web;
using System.Drawing;

namespace CodeCampSchedule
{


	public class SessionDetailsSource : UITableViewSource
	{

		IList<SessionSectionData> sectionData;
		public SessionDetailsSource (Session session)
		{
			var cellId = "section1";
			
				
				
			sectionData = new List<SessionSectionData> 
			{ 
				new SessionSectionData (cellId) 
				{ 
					Title = "Session", 
					Data = new List<UITableViewCell> 
					{ 
						new TextWrapCell(session.Title, UIFont.FromName("Helvetica-Bold", 14f), 275, cellId),
						new HeaderValueCell ("Speaker", session.SpeakerName, cellId), 
						new HeaderValueCell ("Track", session.Track, cellId), 
						new HeaderValueCell ("Time", session.Time.ToString ("h:mm"), cellId), 
						new HeaderValueCell ("Room", session.Room, cellId) 
					} 
				},
				new SessionSectionData (cellId)
				{
					Title = "Description",
					Data = new List<UITableViewCell>
					{
						new SessionTitleCell(session.Description, cellId)
					}
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
			
			var cell = tableView.DequeueReusableCell (cellId);
			if (cell == null) {
				cell = row;
			}
			
			return cell;
		}
		
		
		public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return sectionData[indexPath.Section].Data[indexPath.Row].Frame.Height;
		}

		
	}

	class SessionSectionData
	{
		public string Title { get; set; }
		public string CellId { get; set; }
		public IList<UITableViewCell> Data { get; set; }

		public SessionSectionData (string cellId)
		{
			CellId = cellId;
		}
	}

	class SessionTitleCell : UITableViewCell
	{

		public SessionTitleCell (string title, string cellId) : base(UITableViewCellStyle.Default, cellId)
		{
			TextLabel.Text = title;
		}
	}

	class HeaderValueCell : UITableViewCell
	{
		public HeaderValueCell (string header, string val, string cellId) : base(UITableViewCellStyle.Value1, cellId)
		{
			TextLabel.Text = header;
			DetailTextLabel.Text = val;
		}
	}
	
	class TextWrapCell: UITableViewCell
	{
		UILabel labelView;
		UIView view;
		float width;
		public TextWrapCell(string text, UIFont font, float width, string cellID):base(UITableViewCellStyle.Default, cellID)
		{
			this.width = width;
			labelView = new UILabel
			{
				Text = text,
				Font = font,
				Lines = 0,
				LineBreakMode = UILineBreakMode.WordWrap
			};
			SetLabelHeight(labelView);
			view = new UIView();
			Frame = new RectangleF(0, 0, 320, labelView.Frame.Height + 20);
			view.Frame = new RectangleF(15, 0, 275, labelView.Frame.Height);
			view.AddSubview(labelView);
			ContentView.AddSubview(view);
		}

		void SetLabelHeight (UILabel label)
		{
			var stringSize = StringSize (label.Text, label.Font, new SizeF (width, 1000f), UILineBreakMode.WordWrap);
			label.Frame = new RectangleF (0, 10, width, stringSize.Height);
		}

	}
	
}
