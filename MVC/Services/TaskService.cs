using MVC.Data.DAL.Repository;
using MVC.Data.Domain.Models;
using Task = MVC.Data.Domain.Models.Task;

namespace MVC.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public Task Create(Task task)
        {
            return _taskRepository.Create(task);
        }

        public IList<Task> GetTask()
        {
            return _taskRepository.GetTasks();
        }
    }
}
