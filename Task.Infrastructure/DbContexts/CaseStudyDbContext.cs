using CaseStudy.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Infrastructure.DbContexts
{
    public class CaseStudyDbContext : DbContext
    {
        public CaseStudyDbContext(DbContextOptions<CaseStudyDbContext> options) : base(options)
        {

        }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
    }
}
