using System;

namespace UmugandaTracker.Models
{
    public class UmugandaEvent
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public int ZoneID { get; set; }
    }
}