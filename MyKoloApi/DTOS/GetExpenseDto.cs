using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyKoloApi.DTOS
{
    public class GetExpenseDto
    {
        public string ExpenseId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}
