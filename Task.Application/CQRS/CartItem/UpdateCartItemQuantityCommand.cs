using CaseStudy.Core.Utils.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Application.CQRS
{
    public class UpdateCartItemQuantityCommand:IRequest<IResult>
    {
        public int ProductId { get; set; }
        public string Token { get; set; }
        public byte Quantity { get; set; }
    }
}
