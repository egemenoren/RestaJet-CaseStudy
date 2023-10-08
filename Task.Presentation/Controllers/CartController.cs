using AutoMapper;
using CaseStudy.Application.CQRS;
using CaseStudy.Application.Dtos.Cart;
using CaseStudy.Core.Entities.Dtos;
using CaseStudy.Core.Utils.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CaseStudy.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CartController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost("Create")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateCartRequest request, CancellationToken cancellationToken = default)
        {
            var command = _mapper.Map<CreateCartCommand>(request);
            var result = await _mediator.Send(command, cancellationToken);
            if (result == null)
                return BadRequest();
            var response = _mapper.Map<CreateCartResponse>(result.Data);
            return Ok(response);
        }
        [HttpPost("AddItem")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddItemToCart([FromBody] AddItemToCartRequest request, CancellationToken cancellationToken = default)
        {
            var command = _mapper.Map<AddCartItemCommand>(request);
            var result = await _mediator.Send(command, cancellationToken);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            return Ok(result);
        }
        [HttpPut("UpdateCartItemQuantity")]
        [ProducesResponseType(typeof(Core.Utils.Results.IResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateCartItemQuantity([FromBody] UpdateCartItemQuantityRequest request, CancellationToken cancellationToken = default)
        {
            var command = _mapper.Map<UpdateCartItemQuantityCommand>(request);
            var result = await _mediator.Send(command, cancellationToken);
            if(result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("DeleteCartItem")]
        [ProducesResponseType(typeof(Core.Utils.Results.IResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteCartItem([FromQuery] DeleteCartItemRequest request,CancellationToken cancellationToken = default)
        {
            var command = _mapper.Map<DeleteCartItemCommand>(request);
            var result = await _mediator.Send(command, cancellationToken);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("GetCartSummary")]
        [ProducesResponseType(typeof(CartSummaryResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCartSummary([FromQuery] GetCartSummaryRequest request, CancellationToken cancellationToken = default)
        {
            var query = _mapper.Map<GetCartSummaryQuery>(request);
            var result = await _mediator.Send(query, cancellationToken);
            if(!result.IsSuccess)
                return BadRequest(result);
            return Ok(result.Data);
        }
    }
}
