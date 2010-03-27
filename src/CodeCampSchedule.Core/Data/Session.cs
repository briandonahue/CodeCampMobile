using SQLite;

namespace CodeCampSchedule.Core.Data
{
    public class Session
    {
        [PrimaryKey, AutoIncrement]
        public int SessionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TrackId { get; set; }
        public int TimeSlotId { get; set; }

    }
}