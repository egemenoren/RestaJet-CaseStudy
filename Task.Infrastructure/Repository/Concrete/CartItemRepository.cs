using CaseStudy.Core.Entities;
using CaseStudy.Core.Entities.Base;
using CaseStudy.Core.Interfaces;
using CaseStudy.Infrastructure.DbContexts;
using CaseStudy.Infrastructure.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Infrastructure.Repository.Concrete
{
    public class CartItemRepository : SoftDeleteRepository<CartItem, DbContext>, ICartItemRepository
    {
        public CartItemRepository(CaseStudyDbContext context) : base(context)
        {
        }
    }
}
