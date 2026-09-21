using System.ComponentModel.DataAnnotations;

namespace Quiz1.Dto.StudentDto
{
    public class StudentDto
    {
        public int StudentId { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }

        
        public string Phone { get; set; }

        

        public DateOnly DOF { get; set; }

        public string ClassroomName { get; set; }
    }
}
