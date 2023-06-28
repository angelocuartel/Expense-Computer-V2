using ExpenseComputer.Data;
using ExpenseComputer.Domain;
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

        public ExpenseController(ExpenseManager expenseManager)
        {
            _expenseManager = expenseManager;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetExpense()
        {

            return Ok(await _expenseManager.GetExpenseAsync());
        }

        [HttpGet]
        [Route("assembly")]
        public IActionResult GetClasses()
        {
            var classList = Assembly.GetExecutingAssembly().GetTypes().Where(i => i.IsPublic).Select(i => i.Name);
            return Ok(classList);
        }
    }
}
