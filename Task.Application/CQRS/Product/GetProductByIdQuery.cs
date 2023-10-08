using CaseStudy.Core.Entities.External;
using CaseStudy.Core.Utils.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Application.CQRS.Product
{
    public class GetProductByIdQuery:IRequest<DataResultModel<ProductDetail>>
    {
        public int Id { get; set; }
    }
}
