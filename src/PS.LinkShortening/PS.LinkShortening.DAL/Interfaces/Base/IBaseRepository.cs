namespace PS.LinkShortening.DAL.Interfaces.Base
{
    public interface IBaseRepository<T>
    {
        public Task<T> GetAsync(int id);
        public IQueryable<T> GetAll();

        public Task<T> AddAsync(T entity);
        public Task<T> EditAsync(T entity);
        public Task<T> DeleteAsync(T entity);
    }
}
