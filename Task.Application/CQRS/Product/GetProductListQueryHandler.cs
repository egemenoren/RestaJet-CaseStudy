using CaseStudy.Core.Interfaces;
using CaseStudy.Core.Utils.Results;
using MediatR;

namespace CaseStudy.Application.CQRS.Product
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, IPagedResult<IList<Core.Entities.External.Product>>>
    {
        private readonly IProductService _productService;
        public GetProductListQueryHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IPagedResult<IList<Core.Entities.External.Product>>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetAll(request.skip,request.limit,cancellationToken);
        }
    }
}
