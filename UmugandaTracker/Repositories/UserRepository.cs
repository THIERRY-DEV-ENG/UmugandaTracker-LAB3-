using System.Collections.Generic;
using MySqlConnector;
using UmugandaTracker.Models;

namespace UmugandaTracker.Repositories
{
    public class UserRepository
    {
        public bool Login(string username, string password, out User user)
        {
            user = null;
            using (var con = Database.GetConnection())
            {
                con.Open();
                string q = "SELECT * FROM Users WHERE Username=@u AND Password=@p";
                using (var cmd = new MySqlCommand(q, con))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password);
                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            user = new User
                            {
                                UserID = r.GetInt32("UserID"),
                                FullName = r.GetString("FullName"),
                                Username = r.GetString("Username"),
                                Role = r.GetString("Role")
                            };
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public List<User> GetAll()
        {
            var list = new List<User>();
            using (var con = Database.GetConnection())
            {
                con.Open();
                using (var cmd = new MySqlCommand("SELECT * FROM Users", con))
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new User
                        {
                            UserID = r.GetInt32("UserID"),
                            FullName = r.GetString("FullName"),
                            Username = r.GetString("Username"),
                            Password = r.GetString("Password"),
                            Role = r.GetString("Role")
                        });
            }
            return list;
        }

        public int Add(User u)
        {
            using (var con = Database.GetConnection())
            {
                con.Open();
                string q = "INSERT INTO Users (FullName,Username,Password,Role) VALUES (@n,@u,@p,@r)";
                using (var cmd = new MySqlCommand(q, con))
                {
                    cmd.Parameters.AddWithValue("@n", u.FullName);
                    cmd.Parameters.AddWithValue("@u", u.Username);
                    cmd.Parameters.AddWithValue("@p", u.Password);
                    cmd.Parameters.AddWithValue("@r", u.Role);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int Delete(int id)
        {
            using (var con = Database.GetConnection())
            {
                con.Open();
                using (var cmd = new MySqlCommand("DELETE FROM Users WHERE UserID=@id", con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}