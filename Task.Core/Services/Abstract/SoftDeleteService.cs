using CaseStudy.Core.Entities.Base;
using CaseStudy.Core.Interfaces;
using CaseStudy.Core.Utils.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Services.Abstract
{
    public class SoftDeleteService<T> : BaseService<T>, ISoftDeleteService<T>
        where T: SoftDeletionEntity
    {
        private readonly ISoftDeleteRepository<T> _softDeleteRepository;
        protected SoftDeleteService(ISoftDeleteRepository<T> softDeleteRepository) : base(softDeleteRepository)
        {
            _softDeleteRepository = softDeleteRepository;
        }

        public virtual async Task<IResult> SoftDelete(int id, CancellationToken cancellationToken)
        {
            var entity = await base.GetById(id, cancellationToken);
            if (!entity.IsSuccess)
                return new ResultModel(false, "Item you're trying to delete could not be found");
            await _softDeleteRepository.SoftDelete(id, cancellationToken);
            return new ResultModel(true, "Object successfully deleted.");
        }
    }
}
