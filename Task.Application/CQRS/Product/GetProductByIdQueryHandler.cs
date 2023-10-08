using CaseStudy.Core.Entities.External;
using CaseStudy.Core.Interfaces;
using CaseStudy.Core.Utils.Results;
using CaseStudy.ExternalServices.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Application.CQRS.Product
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, DataResultModel<ProductDetail>>
    {
        private readonly IProductService _productService;
        public GetProductByIdQueryHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<DataResultModel<ProductDetail>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetById(request.Id);
        }
    }
}
