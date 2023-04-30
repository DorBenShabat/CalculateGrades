using CalculateGrades.Data;
using CalculateGrades.Models;
using CalculateGrades.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CalculateGrades.Repository
{
    public class CourseRepository : Repository<Courses>, ICourseRepository
    {
        private ApplicationDB _db;

        public CourseRepository(ApplicationDB db) : base(db)
        {
            _db = db;
        }

        public void Update(Courses obj)
        {
            _db.courses.Update(obj);
        }
    }

}
