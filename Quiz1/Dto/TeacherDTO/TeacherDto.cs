using System.ComponentModel.DataAnnotations;

namespace Quiz1.Dto.TeacherDTO
{
    public class TeacherDto
    {
        public int TeacherId { get; set; }
        
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        
        public string? Phone { get; set; }
        
        public decimal Salary { get; set; }
        public string ?DepartmentName { get; set; }
    }
}
