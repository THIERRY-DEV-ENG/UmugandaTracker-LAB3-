using System;

namespace UmugandaTracker.Models
{
    public class UmugandaEvent
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public int ZoneID { get; set; }
        public string ZoneName { get; set; }
        public string Location { get; set; }

        public string DisplayText
        {
            get
            {
                if (!string.IsNullOrEmpty(ZoneName))
                {
                    return EventName + " (" + ZoneName + " - " + Location + ") - " + EventDate.ToString("dd/MM/yyyy");
                }
                return EventName + " - " + EventDate.ToString("dd/MM/yyyy");
            }
        }
    }
}
