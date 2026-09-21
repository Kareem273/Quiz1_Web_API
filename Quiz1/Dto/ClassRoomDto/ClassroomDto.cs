using System.ComponentModel.DataAnnotations;

namespace Quiz1.Dto.ClassRoomDto
{
    public class ClassroomDto
    {
        public int ClassroomId { get; set; }

        
        public string Name { get; set; }

        
        public int Grade { get; set; }

        
        public int Capacity { get; set; }
    }
}
