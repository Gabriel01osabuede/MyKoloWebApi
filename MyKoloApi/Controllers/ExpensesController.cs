using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyKoloApi.Data;
using MyKoloApi.DTOS;
using MyKoloApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyKoloApi.Controllers
{
    [ApiController]
    [Route("Expenses")]
    public class ExpensesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ExpensesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddExpense(AddExpenseDto requestBody)
        {
            //amount ,description
            Expense expense = new Expense()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = requestBody.UserId,
                Amount = requestBody.Amount,
                Description = requestBody.Description
            };

            _context.Set<Expense>().Add(expense);
            _context.SaveChanges();
            return Ok(expense.Id);
        }

        [HttpGet]
        public IActionResult GetAllCurrentUserExpenses()
        {
            List<Expense> ExpensesData = _context.Expenses.ToList();
            List<GetExpenseDto> Expenses = new List<GetExpenseDto>();
            if(ExpensesData.Count == 0)
            {
                return NotFound();
            }
            else
            {
                foreach(var expenseItem in ExpensesData)
                {
                    Expenses.Add(new GetExpenseDto()
                    { 
                        ExpenseId = expenseItem.Id,
                        Amount = expenseItem.Amount,
                        Description = expenseItem.Description
                    });
                }
                return Ok(Expenses);
            }
        }
        [HttpGet("{UserId}")]
        public IActionResult GetExpensesByUserId(string UserId)
        {
            
            List<Expense> expenses = _context.Expenses.Where(expense =>
                expense.UserId == UserId
            ).ToList();
            if(expenses.Count == 0)
            {
                return NotFound();
            }
            else
            {
                List<GetExpenseDto> FoundExpense = new List<GetExpenseDto>();
                foreach(var itemExpense in expenses)
                {
                    FoundExpense.Add(new GetExpenseDto()
                    {
                        ExpenseId = itemExpense.Id,
                        Amount = itemExpense.Amount,
                        Description = itemExpense.Description,
                    });

                }
                return Ok(FoundExpense);
            }
        }

        [HttpPut]
        public IActionResult UpdateExpense([FromQuery]string UserId,[FromBody] UpdateExpenseDto expenseToUpdate)
        {

            return Ok();
        }
    }
}
