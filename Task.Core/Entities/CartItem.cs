using CaseStudy.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Entities
{
    public class CartItem : SoftDeletionEntity
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public byte Quantity { get; set; }
    }
}
