using ExpenseComputer.Entity;

namespace ExpenseComputer.Data.Repository
{
    public interface IGenericRepository<T>
    {
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetListAsync();

        Task DeleteByIdAsync(int id);

        Task UpdateAsync(T obj);

        Task CreateAsync(T obj);
    }
}
