using AutoMapper;
using CaseStudy.Core.Entities;
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
    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, DataResultModel<Cart>>
    {
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;
        public CreateCartCommandHandler(ICartService cartService, IMapper mapper)
        {
            _cartService = cartService;
            _mapper = mapper;
        }

        public async Task<DataResultModel<Cart>> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            return await _cartService.Create(request, cancellationToken);
        }
    }
}
