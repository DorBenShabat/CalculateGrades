using CalculateGrades.Models;
using System.Linq.Expressions;

namespace CalculateGrades.Repository.IRepository
{
    public interface ICourseRepository : IRepository<Courses>
    {
        void Update(Courses obj);
    }
}
