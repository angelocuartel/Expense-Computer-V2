using ExpenseComputer.Data;
using ExpenseComputer.Data.Repository;
using ExpenseComputer.Entity;
using Microsoft.EntityFrameworkCore;

namespace ExpenseComputerAPI.Implementations
{
    public class ExpenseRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public ExpenseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Expense obj)
        {
            await _context.AddAsync(obj);
        }

        public async Task DeleteByIdAsync(int id)
        {
            DbSet<T> dbSet = _context.Set<T>();

            T obj = await dbSet.FindAsync(id);

            dbSet.Remove(obj);
        }

        public async Task<IEnumerable<T>> GetListAsync()
        => _context.Set<T>();

        Task<T> IGenericRepository<T>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T obj)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(T obj)
        {
            var set = _context.Set<T>();
            await set.AddAsync(obj);
        }
    }
}
