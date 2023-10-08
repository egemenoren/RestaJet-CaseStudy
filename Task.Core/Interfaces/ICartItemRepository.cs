﻿using CaseStudy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Interfaces
{
    public interface ICartItemRepository : ISoftDeleteRepository<CartItem>
    {
    }
}