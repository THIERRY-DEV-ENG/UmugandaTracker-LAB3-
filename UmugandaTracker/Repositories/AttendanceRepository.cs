using System.Collections.Generic;
using System.Data;
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
                using (var cmd = new MySqlCommand("SELECT * FROM Attendance ORDER BY AttendanceID DESC", con))
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

        public AttendanceRecord GetByEventAndUser(int eventId, int userId)
        {
            using (var con = Database.GetConnection())
            {
                con.Open();
                string q = "SELECT * FROM Attendance WHERE EventID=@e AND UserID=@u LIMIT 1";
                using (var cmd = new MySqlCommand(q, con))
                {
                    cmd.Parameters.AddWithValue("@e", eventId);
                    cmd.Parameters.AddWithValue("@u", userId);
                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            return new AttendanceRecord
                            {
                                AttendanceID = r.GetInt32("AttendanceID"),
                                EventID = r.GetInt32("EventID"),
                                UserID = r.GetInt32("UserID"),
                                Status = r.GetString("Status")
                            };
                        }
                    }
                }
            }
            return null;
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

        public int Update(AttendanceRecord a)
        {
            using (var con = Database.GetConnection())
            {
                con.Open();
                string q = "UPDATE Attendance SET EventID=@e, UserID=@u, Status=@s WHERE AttendanceID=@id";
                using (var cmd = new MySqlCommand(q, con))
                {
                    cmd.Parameters.AddWithValue("@e", a.EventID);
                    cmd.Parameters.AddWithValue("@u", a.UserID);
                    cmd.Parameters.AddWithValue("@s", a.Status);
                    cmd.Parameters.AddWithValue("@id", a.AttendanceID);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetReport()
        {
            var dt = new DataTable();
            using (var con = Database.GetConnection())
            {
                con.Open();
                string q = @"SELECT a.AttendanceID, e.EventName, z.ZoneName, u.FullName AS CitizenName, e.EventDate, a.Status 
                             FROM Attendance a 
                             LEFT JOIN UmugandaEvents e ON a.EventID = e.EventID 
                             LEFT JOIN Zones z ON e.ZoneID = z.ZoneID 
                             LEFT JOIN Users u ON a.UserID = u.UserID 
                             ORDER BY a.AttendanceID DESC";
                using (var cmd = new MySqlCommand(q, con))
                using (var da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
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
