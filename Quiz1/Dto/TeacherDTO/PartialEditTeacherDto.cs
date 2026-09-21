using System.ComponentModel.DataAnnotations;

namespace Quiz1.Dto.TeacherDTO
{
    public class PartialEditTeacherDto
    {
        [MaxLength(20), Phone]
        public string? PhoneNumber { get; set; }

        [Required, Range(0, int.MaxValue)]
        public decimal Salary { get; set; }
    }
}
