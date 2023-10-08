using CaseStudy.Core.Services.Abstract;
using CaseStudy.Core.Utils.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Application.CQRS.Order
{
    public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, IResult>
    {
        private readonly IOrderService _orderService;

        public PlaceOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IResult> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            return await _orderService.PlaceOrder(request.Token, cancellationToken);
        }
    }
}
