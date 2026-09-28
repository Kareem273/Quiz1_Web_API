using Quiz1.Models;

namespace Quiz1.Repo.Abstract
{
    public interface ISubjectRepo : IGenericRepo<Subject>
    {
        List<Subject> GetSubjectsByTeacher(int teacherId);
    }
}
