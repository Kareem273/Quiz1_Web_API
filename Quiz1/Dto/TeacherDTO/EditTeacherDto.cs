using System.ComponentModel.DataAnnotations;

namespace Quiz1.Dto.TeacherDTO
{
    public class EditTeacherDto
    {

       
            [Required, MaxLength(100)]
            public string FullName { get; set; }

            [Required, EmailAddress, MaxLength(150)]
            public string EmailAddress { get; set; }

            [MaxLength(20), Phone]
            public string? PhoneNumber { get; set; }

            [Required, Range(0, int.MaxValue)]
            public decimal Salary { get; set; }

            public int DepartmentId { get; set; }
        
    }
}
