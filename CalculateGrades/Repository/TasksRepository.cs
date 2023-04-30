using CalculateGrades.Data;
using CalculateGrades.Models;
using CalculateGrades.Repository.IRepository;

namespace CalculateGrades.Repository
{
    public class TasksRepository: Repository<Tasks>, ITasksRepository
    {
        private ApplicationDB _db;
        public TasksRepository(ApplicationDB db) : base(db)
        {
            _db = db;
        }
        public void Update(Tasks obj)
        {
            _db.Tasks.Update(obj);
        }
    }
}
