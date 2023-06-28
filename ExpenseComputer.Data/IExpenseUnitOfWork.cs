using ExpenseComputer.Data.Repository;
using ExpenseComputer.Entity;

namespace ExpenseComputer.Data
{
    public interface IExpenseUnitOfWork : IDisposable
    {
        IGenericRepository<Expense> ExpenseRepository { get; }

        Task CommitAsync();
        void Rollback();

        void Dispose();
    }
}
