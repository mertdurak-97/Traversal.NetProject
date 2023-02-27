using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using System.Linq.Expressions;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T entity)
        {
            using var c = new AddDbContext();
            c.Remove(entity);
            c.SaveChanges();
        }

        public T GetById(int id)
        {
            using var c = new AddDbContext();
            return c.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            using var c = new AddDbContext();
            return c.Set<T>().ToList();
        }

        public List<T> GetListByFilter(Expression<Func<T, bool>> filter)
        {
            using var c = new AddDbContext();
            return c.Set<T>().Where(filter).ToList();
        }

        public void Insert(T entity)
        {
            using var c = new AddDbContext();
            c.Add(entity);
            c.SaveChanges();
        }

        public void Update(T entity)
        {
            using var c = new AddDbContext();
            c.Update(entity);
            c.SaveChanges();
        }
    }
}
