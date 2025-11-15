using FinanceApp.Data;
using FinanceApp.Data.Serivce;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensesService _expensesService;
        public ExpensesController(IExpensesService expensesService)
        {
            _expensesService = expensesService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var expense = await _expensesService.GetAll();
            return View(expense);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Expense expense)
        {
            if(ModelState.IsValid)
            {
                await _expensesService.Add(expense);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult GetChart()
        {
            var data = _expensesService.GetChartData();
           return Json(data);
        }
    }
}
