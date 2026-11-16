using UmugandaTracker.Models;
using UmugandaTracker.Repositories;

namespace UmugandaTracker.Controllers
{
    public class AuthController
    {
        private readonly UserRepository _repo = new UserRepository();

        public User Login(string username, string password)
        {
            _repo.Login(username, password, out User user);
            return user;
        }
    }
}