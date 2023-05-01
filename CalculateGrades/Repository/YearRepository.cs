using CalculateGrades.Data;
using CalculateGrades.Models;
using CalculateGrades.Repository.IRepository;

namespace CalculateGrades.Repository
{
    public class YearRepository : Repository<Years>, IYearRepository
    {
        private ApplicationDB _db;

        public YearRepository(ApplicationDB db) : base(db)
        {
            _db = db;
        }

        public void Update(Years obj)
        {
            _db.years.Update(obj);
        }
    }
}
