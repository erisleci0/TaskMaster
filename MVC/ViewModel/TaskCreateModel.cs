using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Data.Domain.Models;
using System.Collections.Generic;
using Task = MVC.Data.Domain.Models.Task;

namespace MVC.ViewModel
{
    public class TaskCreateModel
    {
        public Task Task { get; set; }
        public string StatusId { get; set; }
        public TaskCreate TaskCreate { get; set; }
        public List<SelectListItem> Statuses { get; set; }



        public TaskCreateModel()
        {
            Statuses = new List<SelectListItem>();
        }
    }
}
