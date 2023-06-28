using AutoMapper;
using ExpenseComputer.Data;
using ExpenseComputer.Domain;
using ExpenseComputer.Dto.Request;
using ExpenseComputer.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ExpenseComputer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {

        private readonly ExpenseManager _expenseManager;
        private readonly IMapper _mapper;

        public ExpenseController(ExpenseManager expenseManager,IMapper mapper)
        {
            _expenseManager = expenseManager;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetExpense()
        {
            return Ok(await _expenseManager.GetExpenseAsync());
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateExpenseAsync(ExpenseRequestDto model)
        {
            var expense = _mapper.Map<Expense>(model);
            await _expenseManager.AddExpenseAsync(expense);
            return Ok();
        }
    }
}
