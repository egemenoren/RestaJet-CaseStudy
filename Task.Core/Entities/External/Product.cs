using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Entities.External
{
    public class Product
    {
        public int id { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
    }
    public class ProductListRequest
    {
        public List<Product> products { get; set; }
        public int total { get; set; }
        public int skip { get; set; }
        public int limit { get; set; }
    }
}
