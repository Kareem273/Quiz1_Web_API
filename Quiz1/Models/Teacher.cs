using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz1.Models
{
    public class Teacher
    {
        internal string Email;

        public int TeacherId { get; set; }

        [Required,MaxLength(50)]
        public string FirstName { get; set; }

        [Required,MaxLength(50)]

        public string LastName { get; set; }

        [Required , MaxLength(150),EmailAddress]

        public string EmailAddress { get; set; }

        [MaxLength(20),Phone]
        public string Phone { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [ForeignKey("Id")]
        public int DepartmentId { get; set; }

        public Department? Department { get; set; }

        public ICollection<Subject> Subjects { get; set; }

    }
}
