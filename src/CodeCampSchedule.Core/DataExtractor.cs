using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.IO;
using CodeCampSchedule.Core.Data;

namespace CodeCampSchedule.Core
{
	public class DataExtractor
	{
		public IEnumerable<Session> GetSessionData (IEnumerable<TimeSlot> times, Stream stream)
		{
			var titleEx = new Regex ("<div><b>Session:</b>(.+)</div>");
			var trackEx = new Regex ("<div><b>Track:</b>(.+)</div>");
			var roomEx = new Regex ("<div><b>Room:</b>(.+)</div>");
			var timeEx = new Regex ("<div><b>Time:</b>(.+)</div>");
			var designationEx = new Regex ("<div><b>MS-MVP:</b>(.+)</div>");
			var descEx = new Regex ("<div><b>Description:</b>(.+)</div>\\s+<div><b>Bio");
			var bioEx = new Regex ("<div><b>Bio:</b>(.+)</div>\\s+<div><b>Picture");
			var pictureEx = new Regex ("<b>Picture:</b> <a href=\"(.+)\"");
			
			XDocument sessionXml = XDocument.Load (stream);
			var items = from item in sessionXml.Descendants ("item")
				select new { 
					Name = item.Element ("title").Value, 
					Link = item.Element (("link")).Value, 
					Description = item.Element ("description").Value };
			
			foreach (var item in items) {
				var timeString = timeEx.Match (item.Description).Groups[1].Value.Trim ();
				foreach (TimeSlot timeSlot in times) {
					Console.WriteLine(timeSlot.Time.ToString("h:mm"));
				}

				var time = times.FirstOrDefault (t => timeString.Contains (t.Time.ToString ("h:mm")));
				if (time.Time > DateTime.MinValue) {
					yield return new Session { 
						Title = titleEx.Match (item.Description).Groups[1].Value.Trim (), 
						Track = trackEx.Match (item.Description).Groups[1].Value.Trim (), 
						Room = roomEx.Match (item.Description).Groups[1].Value.Trim (), 
						Time = time.Time, Designation = designationEx.Match (item.Description).Groups[1].Value.Trim (), Description = descEx.Match (item.Description).Groups[1].Value.Trim (), SpeakerBio = bioEx.Match (item.Description).Groups[1].Value.Trim (), SpeakerName = item.Name, 
						PhotoUrl = pictureEx.Match (item.Description).Groups[1].Value.Trim () };
				} else {
					continue;
				}
				
			}
			
		}
	}
}
