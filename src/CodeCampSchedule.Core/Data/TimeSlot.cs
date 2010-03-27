using System;
using SQLite;

namespace CodeCampSchedule.Core.Data
{
    public class TimeSlot
    {
        [PrimaryKey, AutoIncrement]
        public int TimeSlotId { get; set; }
        public DateTime Time { get; set; }
    }
}