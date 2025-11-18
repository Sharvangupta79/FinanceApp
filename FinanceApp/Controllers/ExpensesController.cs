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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                await _expensesService.Add(expense);
                return RedirectToAction(nameof(Index));
            }
            return View(expense);
        }

        // Details (Read single)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var expense = await _expensesService.GetById(id.Value);
            if (expense == null) return NotFound();
            return View(expense);
        }

        // Edit (GET)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var expense = await _expensesService.GetById(id.Value);
            if (expense == null) return NotFound();
            return View(expense);
        }

        // Edit (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Expense expense)
        {
            if (id != expense.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    await _expensesService.Update(expense);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _expensesService.GetById(id) == null)
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(expense);
        }

        // Delete (GET) - confirmation
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var expense = await _expensesService.GetById(id.Value);
            if (expense == null) return NotFound();
            return View(expense);
        }

        // Delete (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _expensesService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // Chart data (already present)
        public IActionResult GetChart()
        {
            var data = _expensesService.GetChartData();
            return Json(data);
        }
    }
}
