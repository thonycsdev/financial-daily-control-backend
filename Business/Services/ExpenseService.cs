using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces.Repositories;
using Business.Interfaces.Services;
using Business.ViewModels.Request;
using Business.ViewModels.Response;

namespace Business.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _repository;
        public ExpenseService(IExpenseRepository repository)
        {
            _repository = repository;
        }
        public Task<ExpenseResponse> CreateExpense(ExpenseRequest viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ExpenseResponse> GetExpense(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExpenseResponse>> GetExpenses()
        {
            throw new NotImplementedException();
        }

        public Task<ExpenseResponse> RemoveExpense(int expenseId)
        {
            throw new NotImplementedException();
        }

        public Task<ExpenseResponse> UpdateExpense(ExpenseRequest viewModel, int expenseId)
        {
            throw new NotImplementedException();
        }
    }
}