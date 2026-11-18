using System.Collections.Generic;
using System.Data;
using UmugandaTracker.Models;
using UmugandaTracker.Repositories;

namespace UmugandaTracker.Controllers
{
    public class AttendanceController
    {
        private readonly AttendanceRepository _repo = new AttendanceRepository();

        public List<AttendanceRecord> GetAll() => _repo.GetAll();
        public int Add(AttendanceRecord a) => _repo.Add(a);
        public int Update(AttendanceRecord a) => _repo.Update(a);
        public DataTable GetReport() => _repo.GetReport();
        public int CountByEvent(int eventId) => _repo.CountByEvent(eventId);
    }
}
