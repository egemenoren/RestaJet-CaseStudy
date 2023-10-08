using CaseStudy.Core.Utils.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Services.Abstract
{
    public interface IOrderService
    {
        Task<IResult> PlaceOrder(string token,CancellationToken cancellationToken = default);
    }
}
