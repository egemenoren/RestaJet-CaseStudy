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
    public class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartItemCommand, IResult>
    {
        private readonly ICartItemService _cartItemService;
        public DeleteCartItemCommandHandler(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }
        public async Task<IResult> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
           return await _cartItemService.SoftDelete(request.CartItemId, cancellationToken);
        }
    }
}
