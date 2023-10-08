using CaseStudy.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Entities
{
    public class Cart : BaseEntity
    {
        public string Token { get; set; }
    }
}
