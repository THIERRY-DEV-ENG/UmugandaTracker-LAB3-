using System;
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

        public bool UsernameExists(string username)
        {
            using (var con = Database.GetConnection())
            {
                con.Open();
                using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM Users WHERE Username=@u", con))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public List<User> GetAll()
        {
            var list = new List<User>();
            using (var con = Database.GetConnection())
            {
                con.Open();
                using (var cmd = new MySqlCommand("SELECT * FROM Users ORDER BY UserID", con))
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
                string q = "INSERT INTO Users (FullName, Username, Password, Role) VALUES (@n, @u, @p, @r)";
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

        public int Update(User u)
        {
            using (var con = Database.GetConnection())
            {
                con.Open();
                string q = "UPDATE Users SET FullName = @n, Username = @u, Password = @p, Role = @r WHERE UserID = @id";
                using (var cmd = new MySqlCommand(q, con))
                {
                    cmd.Parameters.AddWithValue("@n", u.FullName);
                    cmd.Parameters.AddWithValue("@u", u.Username);
                    cmd.Parameters.AddWithValue("@p", u.Password);
                    cmd.Parameters.AddWithValue("@r", u.Role);
                    cmd.Parameters.AddWithValue("@id", u.UserID);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int Delete(int id)
        {
            using (var con = Database.GetConnection())
            {
                con.Open();
                using (var cmd = new MySqlCommand("DELETE FROM Users WHERE UserID = @id", con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public List<User> Search(string keyword)
        {
            var list = new List<User>();
            using (var con = Database.GetConnection())
            {
                con.Open();
                string q = "SELECT * FROM Users WHERE FullName LIKE @k OR Username LIKE @k OR Role LIKE @k ORDER BY UserID";
                using (var cmd = new MySqlCommand(q, con))
                {
                    cmd.Parameters.AddWithValue("@k", "%" + keyword + "%");
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
            }
            return list;
        }
    }
}
