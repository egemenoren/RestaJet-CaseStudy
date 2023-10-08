using CaseStudy.Core.Entities;
using CaseStudy.Core.Entities.Base;
using CaseStudy.Core.Interfaces;
using CaseStudy.Core.Services.Abstract;
using CaseStudy.Core.Utils.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Services.Concrete
{
    public class CartItemService : SoftDeleteService<CartItem>,ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly ICartRepository _cartRepository;
        public CartItemService(ICartItemRepository cartItemRepository, ICartRepository cartRepository) : base(cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
            _cartRepository = cartRepository;
        }
        public async Task<DataResultModel<CartItem>> Create(CartItem entity,string token, CancellationToken cancellationToken = default)
        {
            var cart = await GetCart(token);
            var isTokenValid = cart != null;
            if (!isTokenValid)
                return new DataResultModel<CartItem>(false);
            if(await CheckIfItemIsAlreadyIn(cart,entity.ProductId))
                return new DataResultModel<CartItem>(false,"Product already exists in Cart",null);
            entity.CartId = cart.Id;
            entity.Quantity = 1;
            return await base.Create(entity, cancellationToken);
        }
        public async Task<IResult> UpdateCartItemQuantity(int productId,string token,byte quantity,CancellationToken cancellationToken = default)
        {
            var cart = await GetCart(token);
            var isTokenValid = cart != null;
            if (!isTokenValid)
                new ResultModel(false, "Token is Invalid");
            if (await CheckIfItemIsAlreadyIn(cart, productId))
            {
                var cartItem = (await _cartItemRepository.Get(x => x.CartId == cart.Id && x.ProductId == productId)).SingleOrDefault();
                cartItem.Quantity = quantity;
                await base.Update(cartItem,cancellationToken);
                return new ResultModel(true, "Item quantity has successfully been updated.");
            }
            return new ResultModel(false, "Item you're trying to update could not be found");
        }
        private async Task<Cart> GetCart(string token)
        {
            return (await _cartRepository.Get(x => x.Token == token)).SingleOrDefault();
        }
        private async Task<bool> CheckIfItemIsAlreadyIn(Cart cart, int productId)
        {
            return (await _cartItemRepository.Get(x=>x.ProductId == productId && x.CartId == cart.Id)).Any();
        }
    }
}
