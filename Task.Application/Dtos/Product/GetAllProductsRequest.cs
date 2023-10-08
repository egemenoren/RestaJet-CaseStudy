using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Application.Dtos.Product
{
    public class GetAllProductsRequest
    {
        public int PageIndex { get; set; }
        public int Limit { get; set; }
    }
}
