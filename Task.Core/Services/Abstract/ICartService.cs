using CaseStudy.Core.Entities;
using CaseStudy.Core.Entities.Dtos;
using CaseStudy.Core.Utils.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Services.Abstract
{
    public interface ICartService : IBaseService<Cart>
    {
        Task<IDataResult<CartSummaryResult>> GetCartSummary(string token,CancellationToken cancellationToken = default);
    }
}
