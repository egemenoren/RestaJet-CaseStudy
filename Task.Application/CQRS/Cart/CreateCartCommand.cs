using CaseStudy.Core.Entities;
using CaseStudy.Core.Utils.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Application.CQRS
{
    public class CreateCartCommand : Cart, IRequest<DataResultModel<Cart>>
    {
        public CreateCartCommand()
        {
            Token = Guid.NewGuid().ToString();
        }
    }
}
