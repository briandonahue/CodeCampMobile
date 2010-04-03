using System;
using SQLite;

namespace CodeCampSchedule.Core.Data
{
    public class Session
    {
        [PrimaryKey, AutoIncrement]
        public int SessionId { get; set; }
		public string Title { get; set; }
        public string Description { get; set; }
        public string Track { get; set; }
        public DateTime Time { get; set; }
        public string Designation { get; set; }
        public string SpeakerBio { get; set; }
        public string SpeakerName { get; set; }
        public string PhotoUrl { get; set; }
  
    }
}