using FinanceApp.Models;
using System.Collections;

namespace FinanceApp.Data.Serivce
{
    public interface IExpensesService
    {
        Task<IEnumerable<Expense>> GetAll();
        Task Add(Expense expense);

        // CRUD additions:
        Task<Expense?> GetById(int id);
        Task Update(Expense expense);
        Task Delete(int id);

        IQueryable GetChartData();
    }
}
