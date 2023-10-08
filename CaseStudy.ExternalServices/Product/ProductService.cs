using CaseStudy.Core.Entities.External;
using CaseStudy.Core.Interfaces;
using CaseStudy.Core.Services.Abstract;
using CaseStudy.Core.Utils.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.ExternalServices.Product
{
    public class ProductService : IProductService
    {
        private readonly RestSharpService _restSharpService;
        public ProductService(RestSharpService restSharpService)
        {
            _restSharpService = restSharpService;
        }
        public async Task<IPagedResult<IList<Core.Entities.External.Product>>> GetAll(int skip, int limit, CancellationToken cancellationToken = default)
        {
            var pageIndex = skip / limit;
            var url = ProductExternalServiceConstants.BaseUrl + ProductExternalServiceConstants.ProductListEndpoint;
            var result = await _restSharpService.ExecuteWithParameter<ProductListRequest>(url, new { skip = skip, limit = limit }, RestSharp.Method.Get, cancellationToken);
            if (result.IsSuccessful && result.Data != null)
                return new PagedResult<IList<Core.Entities.External.Product>>(result.Data.products,pageIndex, limit);
            return new PagedResult<IList<Core.Entities.External.Product>>(null, pageIndex, limit);

        }
        public async Task<DataResultModel<ProductDetail>> GetById(int id, CancellationToken cancellationToken = default)
        {
            var url = ProductExternalServiceConstants.BaseUrl + ProductExternalServiceConstants.ProductListEndpoint + id;
            var result = await _restSharpService.Execute<ProductDetail>(url, RestSharp.Method.Get, cancellationToken);
            if (result.IsSuccessful && result.Data != null)
                return new DataResultModel<ProductDetail>(true, result.Data);
            return new DataResultModel<ProductDetail>(false, null);
        }
    }
}
