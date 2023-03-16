using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces.Services;
using Business.Services;

namespace API.Extensions
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
            .AddScoped<IExpenseService, ExpenseService>();
        }
    }
}