using CaseStudy.Core.Entities.Base;
using CaseStudy.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Infrastructure.Repository.Abstract
{
    public class SoftDeleteRepository<T, TContext> : BaseRepository<T, TContext>,ISoftDeleteRepository<T>
        where TContext : DbContext
        where T : SoftDeletionEntity, new()
    {
        private readonly DbContext _context;
        protected SoftDeleteRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task SoftDelete(int id, CancellationToken cancellationToken = default)
        {
            var entity = await base.GetById(id);
            if(entity != null)
            {
                entity.IsDeleted = true;
                await base.Update(entity, cancellationToken);
            }
        }
    }
}
