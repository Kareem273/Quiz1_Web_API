using Quiz1.Data;
using Quiz1.Repo.Abstract;

namespace Quiz1.Repo.Implementation
{
    public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class
    {
        private readonly AppDbContext db;

        public GenericRepo(AppDbContext db)
        {
            this.db = db;
        }
        public void Create(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
        }
       

        public List<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        
        }

        public void Update(TEntity entity)
        {
            db.Set<TEntity>().Update(entity);
        }
    }
}
