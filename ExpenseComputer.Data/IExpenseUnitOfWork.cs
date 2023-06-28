using ExpenseComputer.Data.Repository;
using ExpenseComputer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseComputer.Data
{
    public interface IExpenseUnitOfWork : IDisposable
    {
        IGenericRepository<Expense> ExpenseRepository { get; }

        void CreateTransaction();
        void Commit();
        void Rollback();

        void Dispose();
    }
}
