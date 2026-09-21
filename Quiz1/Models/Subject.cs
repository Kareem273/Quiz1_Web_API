using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz1.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }

        [Required,MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required,Range(1,100)]
        public string Grade { get; set; }

        [ForeignKey("TeacherId")]
        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }


        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
