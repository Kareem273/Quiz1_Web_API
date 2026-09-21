using System.ComponentModel.DataAnnotations;
using Quiz1.Models;

namespace Quiz1.Dto.ClassRoomDto
{
    public class CreateClassRoom
    {
        public int ClassroomId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, Range(1, 12)]
        public int Grade { get; set; }

        [Required, Range(1, 100)]
        public int Capacity { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();

    }
}
