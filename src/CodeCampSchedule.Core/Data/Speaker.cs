using SQLite;

namespace CodeCampSchedule.Core.Data
{
    public class Speaker
    {
        [PrimaryKey, AutoIncrement]
        public int SpeakerId { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Bio { get; set; }
        public string PhotoUrl { get; set; }

    }
}