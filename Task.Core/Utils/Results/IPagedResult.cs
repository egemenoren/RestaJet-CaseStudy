using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Utils.Results
{
    public interface IPagedResult<T>
    {
        public int PageIndex { get; set; }
        public int Limit { get; set; }
        public T Data { get; set; }
    }
}
