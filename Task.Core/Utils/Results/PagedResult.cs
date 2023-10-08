using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Utils.Results
{
    public class PagedResult<T> : IPagedResult<T>
    {
        public PagedResult(T data,int pageIndex,int limit)
        {
            Data = data;
            PageIndex = pageIndex;
            Limit = limit;
        }
        public int PageIndex { get; set; }
        public int Limit { get; set; }
        public T Data { get; set; }
    }
}
