using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Entities;
using Business.Interfaces.Repositories;
using Business.Interfaces.Services;
using Business.ViewModels.Request;
using Business.ViewModels.Response;

namespace Business.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _repository;
        private readonly IMapper _mapper;
        public ExpenseService(IExpenseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ExpenseResponse> CreateExpense(ExpenseRequest viewModel)
        {
            if (viewModel.Name == null || viewModel.Price == null || viewModel.purchaseDate == null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }
            var entity = _mapper.Map<Expense>(viewModel);
             await _repository.CreateAsync(entity);
            return _mapper.Map<ExpenseResponse>(entity);
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