using System.Collections.Generic;
using UmugandaTracker.Models;
using UmugandaTracker.Repositories;

namespace UmugandaTracker.Controllers
{
    public class ZoneController
    {
        private readonly ZoneRepository _repo = new ZoneRepository();

        public List<Zone> GetAll() => _repo.GetAll();
        public int Add(Zone z) => _repo.Add(z);
        public int Update(Zone z) => _repo.Update(z);
        public int Delete(int id) => _repo.Delete(id);
        public List<Zone> Search(string keyword) => _repo.Search(keyword);
    }
}
