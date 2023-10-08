using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Utils.Results
{
    public interface IResult
    {
        public bool IsSuccess { get; }
        public string Message { get; }

    }
    public interface IDataResult<T>:IResult
    {
        public T Data { get; }
    }
}
