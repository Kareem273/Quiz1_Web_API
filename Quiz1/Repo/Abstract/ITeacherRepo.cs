using Quiz1.Models;

namespace Quiz1.Repo.Abstract
{
    public interface ITeacherRepo : IGenericRepo<Teacher>
    {
        List<Teacher> GetTeachersByDepartment(int departmentId);
    }
}
