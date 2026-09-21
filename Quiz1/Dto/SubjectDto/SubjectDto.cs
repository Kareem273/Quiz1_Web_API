using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz1.Dto.SubjectDto
{
    public class SubjectDto
    {
        public int SubjectId { get; set; }

        
        public string Name { get; set; }

        
        public string Description { get; set; }

        
        public string Grade { get; set; }

        
        public int TeacherId { get; set; }

        public string TeacherName { get; set; }
    }
}
