namespace UmugandaTracker.Models
{
    public class AttendanceRecord
    {
        public int AttendanceID { get; set; }
        public int EventID { get; set; }
        public int UserID { get; set; }
        public string Status { get; set; }
    }
}