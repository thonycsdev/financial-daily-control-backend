using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        private readonly IConfiguration _configuration;

        public DataContext()
        {

        }
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=app.db; cache=Shared");
        }
    }
}