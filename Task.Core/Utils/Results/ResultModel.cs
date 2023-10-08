using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Utils.Results
{
    public class ResultModel : IResult
    {
        public ResultModel()
        {

        }
        public ResultModel(bool success, string message)
        {
            IsSuccess = success;
            Message = message;
        }
        public ResultModel(bool success)
        {
            IsSuccess = success;
        }

        public bool IsSuccess { get; }
        public string Message { get; }
    }
    public class DataResultModel<T> : IDataResult<T>
    {
        public DataResultModel(bool success, string message,T data)
        {
            IsSuccess=success;
            Message = message;
            Data = data;
        }
        public DataResultModel(bool success, T data)
        {
            IsSuccess = success;
            Data = data;
        }
        public DataResultModel(bool success)
        {
            IsSuccess = success;
        }
        public T Data { get; }

        public bool IsSuccess { get; }

        public string Message { get;  }
    }
}
