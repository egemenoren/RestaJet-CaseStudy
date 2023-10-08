using CaseStudy.Core.Entities;
using CaseStudy.Core.Interfaces;
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
    public class AddCartItemCommandHandler : IRequestHandler<AddCartItemCommand, IResult>
    {
        private readonly ICartItemService _cartItemService;
        public AddCartItemCommandHandler(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }
        public async Task<IResult> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
        {
            var cartItem = new CartItem
            {
                ProductId = request.ProductId,
            };
            var result = await _cartItemService.Create(cartItem, request.Token, cancellationToken);
            if (result.IsSuccess)
                return new ResultModel(true);
            return new ResultModel(false, result.Message);
        }
    }
}
