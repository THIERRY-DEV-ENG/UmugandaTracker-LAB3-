using System.Collections.Generic;
using MySqlConnector;
using UmugandaTracker.Models;

namespace UmugandaTracker.Repositories
{
    public class AttendanceRepository
    {
        public List<AttendanceRecord> GetAll()
        {
            var list = new List<AttendanceRecord>();
            using (var con = Database.GetConnection())
            {
                con.Open();
                using (var cmd = new MySqlCommand("SELECT * FROM Attendance", con))
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new AttendanceRecord
                        {
                            AttendanceID = r.GetInt32("AttendanceID"),
                            EventID = r.GetInt32("EventID"),
                            UserID = r.GetInt32("UserID"),
                            Status = r.GetString("Status")
                        });
            }
            return list;
        }

        public int Add(AttendanceRecord a)
        {
            using (var con = Database.GetConnection())
            {
                con.Open();
                string q = "INSERT INTO Attendance (EventID,UserID,Status) VALUES (@e,@u,@s)";
                using (var cmd = new MySqlCommand(q, con))
                {
                    cmd.Parameters.AddWithValue("@e", a.EventID);
                    cmd.Parameters.AddWithValue("@u", a.UserID);
                    cmd.Parameters.AddWithValue("@s", a.Status);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int CountByEvent(int eventId)
        {
            using (var con = Database.GetConnection())
            {
                con.Open();
                using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM Attendance WHERE EventID=@id", con))
                {
                    cmd.Parameters.AddWithValue("@id", eventId);
                    return System.Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }
}