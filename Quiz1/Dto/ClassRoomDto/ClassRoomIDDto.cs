using System.ComponentModel.DataAnnotations;
using Quiz1.Models;

namespace Quiz1.Dto.ClassRoomDto
{
    public class ClassRoomIDDto
    {
        public int ClassroomId { get; set; }

        
        public string Name { get; set; }

        
        public int Grade { get; set; }

        
        public int Capacity { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
