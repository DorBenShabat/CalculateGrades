using CalculateGrades.Data;
using CalculateGrades.Repository.IRepository;
using CalculateGrades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateGrades.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDB _db;

        public UnitOfWork(ApplicationDB db)
        {
            _db = db;
            Course = new CourseRepository(_db);
            Tasks = new TasksRepository(_db);
            Years = new YearRepository(_db);
        }
        public ICourseRepository Course { get; private set; }
        public ITasksRepository Tasks { get; private set; }
        public IYearRepository Years { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
