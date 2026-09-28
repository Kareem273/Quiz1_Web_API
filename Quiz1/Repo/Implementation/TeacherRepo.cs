using Quiz1.Data;
using Quiz1.Models;
using Quiz1.Repo.Abstract;

namespace Quiz1.Repo.Implementation
{
    public class TeacherRepo : GenericRepo<Teacher>, ITeacherRepo
    {
        private readonly AppDbContext db;

        public TeacherRepo(AppDbContext db) : base(db)
        {
            this.db = db;
        }

        public List<Teacher> GetTeachersByDepartment(int departmentId)
        {
            return db.Teachers
                .Where(x => x.DepartmentId == departmentId)
                .ToList();
        }
    }
}
