using ExpenseComputer.Data.Repository;
using ExpenseComputer.Entity;
using ExpenseComputerAPI.Implementations;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseComputer.Data
{
    public sealed class ExpenseUnitOfWork : IExpenseUnitOfWork
    {
        private readonly ExpenseRepository<Expense> _expenseRepository;

        private readonly AppDbContext _dbContext;
        public ExpenseUnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;

            _expenseRepository = new ExpenseRepository<Expense>(_dbContext);
        }
        public IGenericRepository<Expense> ExpenseRepository => _expenseRepository;

        public void Commit()
        {
            if(_dbContext is null)
            {
                throw new NullReferenceException("No context was created");
            }
            else
            {
                _dbContext.SaveChangesAsync();
            }
        }

        public void Rollback()
        {
            if(_dbContext is null)
            {
                throw new NullReferenceException("No context was created");
            }
            else
            {
                UpdateChangedEntriesFromDbContext();
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        //private void Dispose(bool disposing)
        //{
        //    if (!_contextIsDisposed)
        //    {
        //        if (disposing)
        //        {
        //            _dbContext.Dispose();
        //        }
        //    }

        //    _contextIsDisposed = true;
        //}

        private void UpdateChangedEntriesFromDbContext()
        {
            var changedEntries = _dbContext.ChangeTracker.Entries()
                   .Where(i => i.State != Microsoft.EntityFrameworkCore.EntityState.Unchanged);

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case Microsoft.EntityFrameworkCore.EntityState.Added:
                        entry.State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                        break;
                    case Microsoft.EntityFrameworkCore.EntityState.Deleted:
                    case Microsoft.EntityFrameworkCore.EntityState.Modified:
                        entry.Reload();
                        break;
                }
            }
        }
    }
}
