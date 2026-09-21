using System.ComponentModel.DataAnnotations;

namespace Quiz1.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required,Range(1,100)]
        public string Name { get; set; }

        [Range(1,500)]
        public string Description { get; set; }

        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
      
    }
}
