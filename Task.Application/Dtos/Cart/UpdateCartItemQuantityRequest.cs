using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Application.Dtos.Cart
{
    public class UpdateCartItemQuantityRequest
    {
        public int ProductId { get; set; }
        public byte Quantity { get; set; }
        public string Token { get; set; }
    }
}
