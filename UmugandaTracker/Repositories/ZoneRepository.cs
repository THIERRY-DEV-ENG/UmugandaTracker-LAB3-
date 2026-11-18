using System.Collections.Generic;
using MySqlConnector;
using UmugandaTracker.Models;

namespace UmugandaTracker.Repositories
{
    public class ZoneRepository
    {
        public List<Zone> GetAll()
        {
            var list = new List<Zone>();
            using (var con = Database.GetConnection())
            {
                con.Open();
                using (var cmd = new MySqlCommand("SELECT * FROM Zones ORDER BY ZoneID", con))
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new Zone
                        {
                            ZoneID = r.GetInt32("ZoneID"),
                            ZoneName = r.GetString("ZoneName"),
                            Location = r.GetString("Location")
                        });
            }
            return list;
        }

        public int Add(Zone z)
        {
            using (var con = Database.GetConnection())
            {
                con.Open();
                string q = "INSERT INTO Zones (ZoneName, Location) VALUES (@n, @l)";
                using (var cmd = new MySqlCommand(q, con))
                {
                    cmd.Parameters.AddWithValue("@n", z.ZoneName);
                    cmd.Parameters.AddWithValue("@l", z.Location);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int Update(Zone z)
        {
            using (var con = Database.GetConnection())
            {
                con.Open();
                string q = "UPDATE Zones SET ZoneName = @n, Location = @l WHERE ZoneID = @id";
                using (var cmd = new MySqlCommand(q, con))
                {
                    cmd.Parameters.AddWithValue("@n", z.ZoneName);
                    cmd.Parameters.AddWithValue("@l", z.Location);
                    cmd.Parameters.AddWithValue("@id", z.ZoneID);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int Delete(int id)
        {
            using (var con = Database.GetConnection())
            {
                con.Open();
                using (var cmd = new MySqlCommand("DELETE FROM Zones WHERE ZoneID = @id", con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Zone> Search(string keyword)
        {
            var list = new List<Zone>();
            using (var con = Database.GetConnection())
            {
                con.Open();
                string q = "SELECT * FROM Zones WHERE ZoneName LIKE @k OR Location LIKE @k ORDER BY ZoneID";
                using (var cmd = new MySqlCommand(q, con))
                {
                    cmd.Parameters.AddWithValue("@k", "%" + keyword + "%");
                    using (var r = cmd.ExecuteReader())
                        while (r.Read())
                            list.Add(new Zone
                            {
                                ZoneID = r.GetInt32("ZoneID"),
                                ZoneName = r.GetString("ZoneName"),
                                Location = r.GetString("Location")
                            });
                }
            }
            return list;
        }
    }
}
