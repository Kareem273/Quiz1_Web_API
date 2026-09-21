using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz1.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }

        [ForeignKey("StudentId")]
        public int StudentId { get; set; }

        public Student Student { get; set; }
        
        [ForeignKey("SubjetId")]
        public int SubjecttId { get; set; }

        public Subject Subject { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        public decimal Grade { get; set; }

    }
}
