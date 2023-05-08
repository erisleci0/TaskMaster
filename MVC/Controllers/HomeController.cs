using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MVC.Data.Domain.Models;
using MVC.Services;
using MVC.ViewModel;
using System.Diagnostics;
using System.Security.Claims;
using Task = MVC.Data.Domain.Models.Task;
using IdentityDbContext = MVC.Areas.Identity.Data.IdentityDbContext;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IdentityDbContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ITaskService taskService, IdentityDbContext db)
        {
            _logger = logger;
            _taskService = taskService;
            _db = db;
        }


        public IActionResult Index()
        {
            var task = _taskService.GetTask();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = task.Where(a => a.UserID == userId).ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            var statusData = _db.Statuses.ToList();

            var model = new TaskCreateModel();
            model.Statuses = new List<SelectListItem>();

            foreach (var status in statusData)
            {
                model.Statuses.Add(new SelectListItem { Text = status.Name, Value = status.Id });
            }

            return View(model);

        }

        [HttpPost]
        public IActionResult Create(TaskCreateModel taskCreateModel)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var statusId = taskCreateModel.StatusId;
            Task task = new Task()
            {
                Id = taskCreateModel.TaskCreate.Id,
                Name = taskCreateModel.TaskCreate.Name,
                Description = taskCreateModel.TaskCreate.Description,
                UserID = userId,
                StatusId = statusId
            };

            _db.Tasks.Add(task);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var taskFromDb = _db.Tasks.Find(id);

            if (taskFromDb == null)
            {
                return NotFound();
            }
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (Status status in _db.Statuses)
            {
                SelectListItem selectListItem = new SelectListItem()
                {
                    Text = status.Name,
                    Value = status.Id
                };
                selectListItems.Add(selectListItem);
            }
            ViewBag.Statuses = selectListItems;

            return View(taskFromDb);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Task task)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var statusId = task.StatusId;
            task.UserID = userId;

            _db.Tasks.Update(task);
            _db.SaveChanges();
            return RedirectToAction("Index");
            //return View(task);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var taskFromDb = _db.Tasks.Find(id);

            if (taskFromDb == null)
            {
                return NotFound();
            }

            return View(taskFromDb);

        }

        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Tasks.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Tasks.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}