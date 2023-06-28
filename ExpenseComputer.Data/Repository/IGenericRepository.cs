using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseComputer.Data.Repository
{
    public interface IGenericRepository <T>
    {
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetListAsync();

        Task DeleteByIdAsync(int id);

        Task UpdateAsync(T obj);

        Task CreateAsync(T obj);
    }
}
