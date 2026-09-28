using Quiz1.Data;
using Quiz1.Models;
using Quiz1.Repo.Abstract;

namespace Quiz1.Repo.Implementation
{
    public class SubjectRepo : GenericRepo<Subject>, ISubjectRepo
    {
        private readonly AppDbContext db;

        public SubjectRepo(AppDbContext db) : base(db)
        {
            this.db = db;
        }

        public List<Subject> GetSubjectsByTeacher(int teacherId)
        {
            return db.Subjects
                .Where(x => x.TeacherId == teacherId)
                .ToList();
        }
    }
}
