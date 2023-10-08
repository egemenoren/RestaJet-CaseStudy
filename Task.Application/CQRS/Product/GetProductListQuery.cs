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
    public class GetProductListQuery:IRequest<IPagedResult<IList<Core.Entities.External.Product>>>
    {
        public int limit { get; set; }
        public int skip { get; set; }
    }
}
