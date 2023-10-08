using CaseStudy.Core.Entities.Dtos;
using CaseStudy.Core.Services.Abstract;
using CaseStudy.Core.Utils.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Application.CQRS
{
    public class GetCartSummaryQueryHandler : IRequestHandler<GetCartSummaryQuery, IDataResult<CartSummaryResult>>
    {
        private readonly ICartService _cartService;
        public GetCartSummaryQueryHandler(ICartService cartService)
        {
            _cartService = cartService;
        }
        public async Task<IDataResult<CartSummaryResult>> Handle(GetCartSummaryQuery request, CancellationToken cancellationToken)
        {
            return await _cartService.GetCartSummary(request.Token,cancellationToken);
        }
    }
}
