using CalculateGrades.Models;

namespace CalculateGrades.Repository.IRepository
{
    public interface ITasksRepository: IRepository<Tasks>
    {
        void Update(Tasks obj);
    }
}
