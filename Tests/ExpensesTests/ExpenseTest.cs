using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using AutoMapper;
using Moq;
using Business.Interfaces.Repositories;
using Business.AutoMapper;
using Business.Entities;
using AutoFixture;
using Business.Services;
using Business.ViewModels.Request;
using Business.ViewModels.Response;

namespace Tests.ExpensesTests
{
    public class ExpenseTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IExpenseRepository> _expenseRepositoryMock;
        public ExpenseTest()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new AutoMapperConfig())).CreateMapper();
            _expenseRepositoryMock= new Mock<IExpenseRepository>();
            SetupMocks();
        }

        private void SetupMocks()
        {
            _expenseRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<Expense>())).ReturnsAsync(It.IsAny<Expense>());

        }
        

        [Fact]
        public async void GivenAExpenseMustReturnItsResponseWithTheName()
        {
            var expectedExpenseName = "Monitor";
            var expectedResult = new Fixture().Create<ExpenseResponse>();
            expectedResult.Name = expectedExpenseName;

            var request = new Fixture().Create<ExpenseRequest>();
            request.Name = null;

            var service = new ExpenseService(_expenseRepositoryMock.Object, _mapper);
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>  await service.CreateExpense(request));
            //var result = await service.CreateExpense(request);

            //Assert.Equal(expectedResult.Name, result.Name);
        }
    }
}