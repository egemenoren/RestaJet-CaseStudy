using CaseStudy.Core.Entities.External;
using CaseStudy.Core.Utils.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Interfaces
{
    public interface IProductService
    {
        Task<IPagedResult<IList<Core.Entities.External.Product>>> GetAll(int skip, int limit, CancellationToken cancellationToken = default);
        Task<DataResultModel<ProductDetail>> GetById(int id, CancellationToken cancellationToken = default);
    }
}
