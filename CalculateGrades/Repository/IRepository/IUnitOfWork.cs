using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateGrades.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICourseRepository Course { get; }
        ITasksRepository Tasks { get; }

        void Save();
    }
}
