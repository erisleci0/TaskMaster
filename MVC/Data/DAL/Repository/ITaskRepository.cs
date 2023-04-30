using Task = MVC.Data.Domain.Models.Task;

namespace MVC.Data.DAL.Repository
{
    public interface ITaskRepository
    {
        IList<Task> GetTasks();
        Task Create(Task task);
    }
}
