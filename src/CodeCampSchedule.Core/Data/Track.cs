using SQLite;

namespace CodeCampSchedule.Core.Data
{
    public class Track
    {
        [PrimaryKey, AutoIncrement]
        public int TrackId { get; set; }
        public string Name { get; set; }
    }
}