using MVC.Data.Domain.Models;
using Task = MVC.Data.Domain.Models.Task;

namespace MVC.Services
{
    public interface ITaskService
    {
        IList<Task> GetTask();
        Task Create(Task task);
    }
}
