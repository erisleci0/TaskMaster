using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Areas.Identity.Data;

namespace MVC.Data.Domain.Models
{
    public class Task : TaskCreate
    {
        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Status")]
        public string StatusId { get; set; }
        public Status Status { get; set; }

    }
}
