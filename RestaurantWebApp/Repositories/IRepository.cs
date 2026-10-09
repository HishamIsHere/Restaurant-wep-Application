namespace WebAppTemplate.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void ChangeStatus(int id);
        T GetById(int id);
        List<T> GetAll();
        List<T> GetAllClient();
    }
}
