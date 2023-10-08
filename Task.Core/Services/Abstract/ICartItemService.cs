using CaseStudy.Core.Entities;
using CaseStudy.Core.Utils.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Services.Abstract
{
    public interface ICartItemService:ISoftDeleteService<CartItem>,IBaseService<CartItem>
    {
        Task<DataResultModel<CartItem>> Create(CartItem entity, string token, CancellationToken cancellationToken = default);
        Task<IResult> UpdateCartItemQuantity(int productId, string token, byte quantity, CancellationToken cancellationToken = default);
    }
}
