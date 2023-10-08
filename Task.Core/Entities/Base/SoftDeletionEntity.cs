using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Entities.Base
{
    public abstract class SoftDeletionEntity : BaseEntity, ISoftDeletionEntity
    {
        public bool IsDeleted { get; set; } = false;
    }
}
