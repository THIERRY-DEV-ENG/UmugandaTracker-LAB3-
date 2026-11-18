using System.Collections.Generic;
using MySqlConnector;
using UmugandaTracker.Models;

namespace UmugandaTracker.Repositories
{
    public class EventRepository
    {
        public List<UmugandaEvent> GetAll()
        {
            var list = new List<UmugandaEvent>();
            using (var con = Database.GetConnection())
            {
                con.Open();
                using (var cmd = new MySqlCommand("SELECT * FROM UmugandaEvents ORDER BY EventID", con))
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new UmugandaEvent
                        {
                            EventID = r.GetInt32("EventID"),
                            EventName = r.GetString("EventName"),
                            EventDate = r.GetDateTime("EventDate"),
                            ZoneID = r.GetInt32("ZoneID")
                        });
            }
            return list;
        }

        public int Add(UmugandaEvent e)
        {
            using (var con = Database.GetConnection())
            {
                con.Open();
                string q = "INSERT INTO UmugandaEvents (EventName,EventDate,ZoneID) VALUES (@n,@d,@z)";
                using (var cmd = new MySqlCommand(q, con))
                {
                    cmd.Parameters.AddWithValue("@n", e.EventName);
                    cmd.Parameters.AddWithValue("@d", e.EventDate);
                    cmd.Parameters.AddWithValue("@z", e.ZoneID);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int Update(UmugandaEvent e)
        {
            using (var con = Database.GetConnection())
            {
                con.Open();
                string q = "UPDATE UmugandaEvents SET EventName = @n, EventDate = @d, ZoneID = @z WHERE EventID = @id";
                using (var cmd = new MySqlCommand(q, con))
                {
                    cmd.Parameters.AddWithValue("@n", e.EventName);
                    cmd.Parameters.AddWithValue("@d", e.EventDate);
                    cmd.Parameters.AddWithValue("@z", e.ZoneID);
                    cmd.Parameters.AddWithValue("@id", e.EventID);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int Delete(int id)
        {
            using (var con = Database.GetConnection())
            {
                con.Open();
                using (var cmd = new MySqlCommand("DELETE FROM UmugandaEvents WHERE EventID=@id", con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public List<UmugandaEvent> Search(string keyword)
        {
            var list = new List<UmugandaEvent>();
            using (var con = Database.GetConnection())
            {
                con.Open();
                string q = "SELECT * FROM UmugandaEvents WHERE EventName LIKE @k ORDER BY EventID";
                using (var cmd = new MySqlCommand(q, con))
                {
                    cmd.Parameters.AddWithValue("@k", "%" + keyword + "%");
                    using (var r = cmd.ExecuteReader())
                        while (r.Read())
                            list.Add(new UmugandaEvent
                            {
                                EventID = r.GetInt32("EventID"),
                                EventName = r.GetString("EventName"),
                                EventDate = r.GetDateTime("EventDate"),
                                ZoneID = r.GetInt32("ZoneID")
                            });
                }
            }
            return list;
        }
    }
}
