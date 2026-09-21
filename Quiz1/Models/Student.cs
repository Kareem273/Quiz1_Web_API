using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz1.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required,MaxLength(50)]
        public string Firstname { get; set; }

        [Required,MaxLength(50)]

        public string Lastname { get; set; }

        

        [Required,MaxLength(150),EmailAddress]
        public string Email { get; set; }

        [MaxLength(20),Phone]
        public string Phone { get; set; }

        [Required]

        public DateOnly DOF { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        [ForeignKey("ClassroomId")]
        public int ClassroomId { get; set; }    

        public Classroom? Classroom { get; set; }
    }
}
