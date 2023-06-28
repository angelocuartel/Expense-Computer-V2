using ExpenseComputer.Data;

namespace ExpenseComputer.Domain
{
    public abstract class ManagerBase
    {
        protected readonly IExpenseUnitOfWork _expenseUnitOfWork;
        private bool _unitOfWorkInternallyManaged;
        public ManagerBase(IExpenseUnitOfWork expenseUnitOfWork)
        {
            _expenseUnitOfWork = expenseUnitOfWork;
        }

        public ManagerBase(AppDbContext context)
        {
            _expenseUnitOfWork = new ExpenseUnitOfWork(context);
            _unitOfWorkInternallyManaged = true;
        }

        public void Commit()
        {
            if (_unitOfWorkInternallyManaged)
            {
                _expenseUnitOfWork.Commit();
            }
        }


    }
}
