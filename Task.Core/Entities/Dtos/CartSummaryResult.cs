using CaseStudy.Core.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Entities.Dtos
{
    public class CartSummaryResult
    {
        public int CartId { get; set; }
        public List<CartItem> Items { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
