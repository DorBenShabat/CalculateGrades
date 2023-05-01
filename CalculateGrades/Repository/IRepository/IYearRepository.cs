using CalculateGrades.Models;

namespace CalculateGrades.Repository.IRepository
{
    public interface IYearRepository : IRepository<Years>
    {
        void Update(Years obj);
    }
}
