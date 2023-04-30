using System.ComponentModel.DataAnnotations;

namespace MVC.Data.Domain.Models
{
    public class TaskCreate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
