using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Identity.Data;
using MVC.Data.Domain.Models;
using Task = MVC.Data.Domain.Models.Task;

namespace MVC.Data.DAL.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IdentityDbContext _db;

        public TaskRepository(IdentityDbContext db)
        {
            _db = db;
        }

        public Task Create(Task task)
        {
            _db.Tasks.Add(task);
            _db.SaveChanges();
            return task;
        }

        public IList<Task> GetTasks()
        {
            var model = _db.Tasks.ToList();
            return model;
        }
    }
}
