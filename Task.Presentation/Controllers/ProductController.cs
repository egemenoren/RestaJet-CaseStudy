using AutoMapper;
using CaseStudy.Application.CQRS.Product;
using CaseStudy.Application.Dtos.Product;
using CaseStudy.Core.Entities.External;
using CaseStudy.Core.Utils.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CaseStudy.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("list")]
        [ProducesResponseType(typeof(IPagedResult<List<Product>>),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> ListAsync([FromQuery]GetAllProductsRequest request,CancellationToken cancellationToken)
        {
            var query = _mapper.Map<GetProductListQuery>(request);
            var result = await _mediator.Send(query, cancellationToken);
            if(result.Data != null && result.Data.Count != 0)
                return Ok(result);
            else if (result.Data == null || result.Data.Count == 0)
                return NotFound();
            return BadRequest();
        }
        [HttpGet("getById")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById([FromQuery] GetProductByIdRequest request,CancellationToken cancellationToken)
        {
            var query = _mapper.Map<GetProductByIdQuery>(request);
            var result = await _mediator.Send(query, cancellationToken);
            if (result.IsSuccess && result.Data != null)
                return Ok(result.Data);
            else if (result.Data == null)
                return NotFound();
            return BadRequest(result.Message);
        }
    }
}
