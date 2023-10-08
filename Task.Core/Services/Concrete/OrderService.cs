using CaseStudy.Core.Services.Abstract;
using CaseStudy.Core.Utils.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Services.Concrete
{
    public class OrderService : IOrderService
    {
        public async Task<IResult> PlaceOrder(string token, CancellationToken cancellationToken = default)
        {
            return new ResultModel(true, "Order successfully placed");
        }
    }
}
