namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> TGetList();
        T TGetById(int id);
    }
}
