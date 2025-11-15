using FinanceApp.Models;
using System.Collections;

namespace FinanceApp.Data.Serivce
{
    public interface IExpensesService
    {
        Task<IEnumerable<Expense>> GetAll();
        Task Add(Expense expense);
        IQueryable GetChartData();
    }
}
