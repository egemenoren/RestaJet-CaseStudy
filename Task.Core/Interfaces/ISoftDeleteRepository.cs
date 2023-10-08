using CaseStudy.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Interfaces
{
    public interface ISoftDeleteRepository<T> : IRepository<T>
        where T : SoftDeletionEntity
    {
        Task SoftDelete(int id, CancellationToken cancellationToken = default);
    }
}
