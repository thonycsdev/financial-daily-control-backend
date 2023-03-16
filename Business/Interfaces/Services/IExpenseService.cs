using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.ViewModels.Request;
using Business.ViewModels.Response;

namespace Business.Interfaces.Services
{
    public interface IExpenseService
    {
        Task<IEnumerable<ExpenseResponse>> GetExpenses();
        Task<ExpenseResponse> GetExpense(int id);
        Task<ExpenseResponse> CreateExpense(ExpenseRequest viewModel);
        Task<ExpenseResponse> UpdateExpense(ExpenseRequest viewModel, int expenseId);
        Task<ExpenseResponse> RemoveExpense(int expenseId);
    }
}