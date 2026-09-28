using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Quiz1.Repo.Abstract
{
    public interface IGenericRepo<TEntity> where TEntity : class
    {

        public List<TEntity> GetAll();

        public TEntity GetById(int id);


        public void Create(TEntity entity);

        public void Update(TEntity entity);                                                       


        public void Delete(TEntity entity);

        public void SaveChanges();
    }
}
