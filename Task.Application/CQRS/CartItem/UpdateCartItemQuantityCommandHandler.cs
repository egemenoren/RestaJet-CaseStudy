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
    public class UpdateCartItemQuantityCommandHandler : IRequestHandler<UpdateCartItemQuantityCommand, IResult>
    {
        private readonly ICartItemService _cartItemService;

        public UpdateCartItemQuantityCommandHandler(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        public async Task<IResult> Handle(UpdateCartItemQuantityCommand request, CancellationToken cancellationToken)
        {
            return await _cartItemService.UpdateCartItemQuantity(request.ProductId, request.Token, request.Quantity, cancellationToken);
        }
    }
}
