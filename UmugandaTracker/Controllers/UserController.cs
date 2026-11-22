using System.Collections.Generic;
using UmugandaTracker.Models;
using UmugandaTracker.Repositories;

namespace UmugandaTracker.Controllers
{
    public class UserController
    {
        private readonly UserRepository _repo = new UserRepository();

        public List<User> GetAll() => _repo.GetAll();
        public bool UsernameExists(string username) => _repo.UsernameExists(username);
        public int Add(User u) => _repo.Add(u);
        public int Update(User u) => _repo.Update(u);
        public int Delete(int id) => _repo.Delete(id);
        public List<User> Search(string keyword) => _repo.Search(keyword);
    }
}
