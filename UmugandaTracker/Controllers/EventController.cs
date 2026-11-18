using System.Collections.Generic;
using UmugandaTracker.Models;
using UmugandaTracker.Repositories;

namespace UmugandaTracker.Controllers
{
    public class EventController
    {
        private readonly EventRepository _repo = new EventRepository();

        public List<UmugandaEvent> GetAll() => _repo.GetAll();
        public int Add(UmugandaEvent e) => _repo.Add(e);
        public int Update(UmugandaEvent e) => _repo.Update(e);
        public int Delete(int id) => _repo.Delete(id);
        public List<UmugandaEvent> Search(string keyword) => _repo.Search(keyword);
    }
}
