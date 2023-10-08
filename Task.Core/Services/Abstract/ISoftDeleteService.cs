using CaseStudy.Core.Utils.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Services.Abstract
{
    public interface ISoftDeleteService<T>
    {
        Task<IResult> SoftDelete(int id,CancellationToken cancellationToken);
    }
}
