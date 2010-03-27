using System;

namespace CodeCampSchedule.Core
{
    public class SessionDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Track { get; set; }
        public string Time { get; set; }
        public string Designation { get; set; }

        public string SpeakerBio { get; set; }

        public string SpeakerName { get; set; }

        public string PhotoUrl { get; set; }
    }
}