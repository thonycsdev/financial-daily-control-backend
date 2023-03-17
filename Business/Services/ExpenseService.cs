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
            ValidateViewModel(viewModel);

            var entity = _mapper.Map<Expense>(viewModel);
            await _repository.CreateAsync(entity);
            return _mapper.Map<ExpenseResponse>(entity);
        }


        public Task<ExpenseResponse> GetExpense(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ExpenseResponse>> GetExpenses()
        {
            var expenses = await _repository.GetManyAsync(x => x.Name != null);
            return _mapper.Map<List<ExpenseResponse>>(expenses);
        }

        public async Task<ExpenseResponse> RemoveExpense(int expenseId)
        {
            var expense = await _repository.GetAsync(x => x.Id == expenseId);
            await _repository.DeleteAsync(expense);
            return _mapper.Map<ExpenseResponse>(expense);
        }

        public async Task<ExpenseResponse> UpdateExpense(ExpenseRequest viewModel, int expenseId)
        {
            var expense = await _repository.GetAsync(x => x.Id == expenseId);
            expense.Name = viewModel.Name;
            expense.Description = viewModel.Description;
            expense.Price = viewModel.Price;
            expense.purchaseDate = viewModel.purchaseDate;

            await _repository.UpdateAsync(expense);
            return _mapper.Map<ExpenseResponse>(expense);
        }
        private static void ValidateViewModel(ExpenseRequest viewModel)
        {
            if (viewModel.Name is null || viewModel.Description is null || viewModel.Price == 0)
                throw new ArgumentNullException(nameof(viewModel));
        }
    }
}