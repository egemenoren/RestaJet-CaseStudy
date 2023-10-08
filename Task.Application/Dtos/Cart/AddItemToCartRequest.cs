using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Application.Dtos.Cart
{
    public class AddItemToCartRequest
    {
        public string Token { get; set; }
        public int ProductId { get; set; }
    }
}
