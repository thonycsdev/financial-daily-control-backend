using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces.Services;
using Business.ViewModels.Request;
using Business.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _service;
        public ExpenseController(IExpenseService service)
        {
            _service = service;
        }

        [HttpGet]
        [Produces(typeof(ExpenseResponse))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _service.GetExpenses();
                return Ok(response);

            }
            catch (System.Exception err)
            {

                throw err;
            }
        }

        [HttpPost]
        [Produces(typeof(ExpenseResponse))]
        public async Task<IActionResult> Create(ExpenseRequest viewModel)
        {
            try
            {
                var response = await _service.CreateExpense(viewModel);
                return Ok(response);

            }
            catch (System.Exception err)
            {

                throw err;
            }
        }

        [HttpPut]
        [Produces(typeof(ExpenseResponse))]
        public async Task<IActionResult> Update(ExpenseRequest viewModel, int expenseId)
        {
            try
            {
                var response = await _service.UpdateExpense(viewModel, expenseId);
                return Ok(response);

            }
            catch (System.Exception err)
            {

                throw err;
            }
        }

        [HttpDelete]
        [Produces(typeof(ExpenseResponse))]
        public async Task<IActionResult> Delete(int expenseId)
        {
            try
            {
                var response = await _service.RemoveExpense(expenseId);
                return Ok(response);

            }
            catch (System.Exception err)
            {

                throw err;
            }
        }
    }
}