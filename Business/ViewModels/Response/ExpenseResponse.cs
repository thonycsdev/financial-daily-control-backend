using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.ViewModels.Response
{
    public class ExpenseResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime purchaseDate { get; set; }
    }
}