using System.Collections.Generic;
using UmugandaTracker.Models;
using UmugandaTracker.Repositories;

namespace UmugandaTracker.Controllers
{
    public class UserController
    {
        private readonly UserRepository _repo = new UserRepository();

        public List<User> GetAll() => _repo.GetAll();
        public int Add(User u) => _repo.Add(u);
        public int Delete(int id) => _repo.Delete(id);
    }
}