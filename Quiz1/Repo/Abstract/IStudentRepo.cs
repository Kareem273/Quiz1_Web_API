using Quiz1.Models;

namespace Quiz1.Repo.Abstract
{
    public interface IStudentRepo : IGenericRepo<Student>
    {
        List<Student> GetStudentsByClassroom(int classroomId);
    }
}
