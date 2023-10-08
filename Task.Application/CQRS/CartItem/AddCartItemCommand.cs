using CaseStudy.Core.Utils.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Application.CQRS
{
    public class AddCartItemCommand : IRequest<IResult>
    {
        public string Token { get; set; }
        public int ProductId { get; set; }
    }
}
