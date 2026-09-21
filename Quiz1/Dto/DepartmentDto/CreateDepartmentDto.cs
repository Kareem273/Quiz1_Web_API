using System.ComponentModel.DataAnnotations;

namespace Quiz1.Dto.DepartmentDto
{
    public class CreateDepartmentDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
    