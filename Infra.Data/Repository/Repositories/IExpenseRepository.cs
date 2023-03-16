using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Entities;
using Business.Interfaces.Repositories;

namespace Infra.Data.Repository.Repositories
{
    public class ExpenseRepository : Repository<DataContext, Expense>, IExpenseRepository
    {
        public ExpenseRepository(DataContext context) : base(context)
        {
        }
    }
}