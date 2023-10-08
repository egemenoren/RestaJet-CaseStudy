using CaseStudy.Core.Entities.Base;
using CaseStudy.Core.Utils.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Services.Abstract
{
    public interface IBaseService<T> where T: BaseEntity
    {
        Task<DataResultModel<T>> Create(T entity, CancellationToken cancellationToken = default);
        Task<ResultModel> Delete(int id, CancellationToken cancellationToken = default);
        Task<DataResultModel<T>> Update(T entity, CancellationToken cancellationToken = default);
        Task<DataResultModel<T>> GetById(int id, CancellationToken cancellationToken = default);
        Task<DataResultModel<IEnumerable<T>>> GetAll (CancellationToken cancellationToken = default);
        Task<DataResultModel<IEnumerable<T>>> Get(Expression<Func<T,bool>> filter, CancellationToken cancellationToken = default);

    }
}
