using Quiz1.Data;
using Quiz1.Models;
using Quiz1.Repo.Abstract;

namespace Quiz1.Repo.Implementation
{
    public class StudentRepo : GenericRepo<Student>, IStudentRepo
    {
        private readonly AppDbContext db;

        public StudentRepo(AppDbContext db) : base(db)
        {
            this.db = db;
        }

        public List<Student> GetStudentsByClassroom(int classroomId)
        {
            return db.Students
                .Where(x => x.ClassroomId == classroomId)
                .ToList();
        }
    }
}
