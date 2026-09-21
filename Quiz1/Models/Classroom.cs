using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Quiz1.Models
{
    public class Classroom
    {
        public int ClassroomId { get; set; }

        [Required,MaxLength(50)]
        public string Name { get; set; }

        [Required,Range(1,12)]
        public int Grade { get; set; }

        [Required, Range(1, 100)]
        public int Capacity { get; set; }
        [JsonIgnore]
        public ICollection<Student> Students { get; set; } = new List<Student>();

    }
}
