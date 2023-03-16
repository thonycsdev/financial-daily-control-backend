using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Entities;
using Business.ViewModels.Request;
using Business.ViewModels.Response;

namespace Business.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ExpenseRequest, Expense>();
            CreateMap<Expense, ExpenseResponse>();
        }
    }
}