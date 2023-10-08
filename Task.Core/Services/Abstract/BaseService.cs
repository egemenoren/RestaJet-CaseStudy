using CaseStudy.Core.Entities.Base;
using CaseStudy.Core.Interfaces;
using CaseStudy.Core.Utils.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Services.Abstract
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;

        protected BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<DataResultModel<T>> Create(T entity, CancellationToken cancellationToken = default)
        {
            var result = await _repository.Create(entity, cancellationToken);
            return new DataResultModel<T>(true, result);
        }

        public virtual async Task<ResultModel> Delete(int id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.Delete(id, cancellationToken);
            if (result)
                return new ResultModel(true);
            return new ResultModel(false);
        }

        public virtual async Task<DataResultModel<IEnumerable<T>>> Get(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
        {
            var result = await _repository.Get(filter, cancellationToken);
            if (!result.Any())
                return new DataResultModel<IEnumerable<T>>(false, "No data found", result);
            return new DataResultModel<IEnumerable<T>>(true, result);
        }

        public virtual async Task<DataResultModel<IEnumerable<T>>> GetAll(CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetAll(cancellationToken);
            if (!result.Any())
                return new DataResultModel<IEnumerable<T>>(false, "No data found", result);
            return new DataResultModel<IEnumerable<T>>(true, result);
        }

        public virtual async Task<DataResultModel<T>> GetById(int id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetById(id, cancellationToken);
            if (result == null)
                return new DataResultModel<T>(false, "Data not found", result);
            return new DataResultModel<T>(true, result);

        }

        public virtual async Task<DataResultModel<T>> Update(T entity, CancellationToken cancellationToken = default)
        {
            var result = await _repository.Update(entity, cancellationToken);
            return new DataResultModel<T>(true, result);

        }
    }
}
