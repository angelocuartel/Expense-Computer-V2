using ExpenseComputer.Data;
using ExpenseComputer.Entity;

namespace ExpenseComputer.Domain
{
    public class ExpenseManager : ManagerBase
    {
        public ExpenseManager(IExpenseUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public ExpenseManager(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Expense>> GetExpenseAsync()
        {
            return await _expenseUnitOfWork.ExpenseRepository.GetListAsync();
        }

        public async Task AddExpenseAsync(Expense expense)
        {
            await _expenseUnitOfWork.ExpenseRepository.CreateAsync(expense);
            await _expenseUnitOfWork.CommitAsync();
        }


    }
}