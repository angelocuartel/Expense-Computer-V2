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
        private IDbContextTransaction _dbTransaction;

        private bool _contextIsDisposed;
        public ExpenseUnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;

            _expenseRepository = new ExpenseRepository<Expense>(_dbContext);
        }
        public IGenericRepository<Expense> ExpenseRepository => _expenseRepository;

        public void Commit()
        {
            if(_dbTransaction is null)
            {
                throw new NullReferenceException("No Transaction was created");
            }
            else
            {
                _dbTransaction.Commit();
            }
        }

        public void Rollback()
        {
            if(_dbTransaction is null)
            {
                throw new NullReferenceException("No Transaction was created");
            }
            else
            {
                _dbTransaction.Rollback();
                _dbTransaction.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_contextIsDisposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            _contextIsDisposed = true;
        }

        public void CreateTransaction()
        {
            _dbTransaction = _dbTransaction ?? _dbContext.Database.BeginTransaction();
        }
    }
}
