using AutoMapper;
using CaseStudy.Application.CQRS;
using CaseStudy.Application.Dtos.Order;
using CaseStudy.Core.Utils.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CaseStudy.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public OrderController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost("placeorder")]
        [ProducesResponseType(typeof(ResultModel),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> PlaceOrder(PlaceOrderRequest request, CancellationToken cancellationToken = default)
        {
            var command = _mapper.Map<PlaceOrderCommand>(request);
            var result = await _mediator.Send(command, cancellationToken);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
