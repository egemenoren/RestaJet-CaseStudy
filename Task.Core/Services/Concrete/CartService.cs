using CaseStudy.Core.Entities;
using CaseStudy.Core.Entities.Dtos;
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
    public class CartService : BaseService<Cart>,ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IProductService _productService;
        public CartService(ICartRepository cartRepository, ICartItemRepository cartItemRepository, IProductService productService) : base(cartRepository)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _productService = productService;
        }
        public async Task<IDataResult<CartSummaryResult>> GetCartSummary(string token,CancellationToken cancellationToken = default)
        {
            var cart = (await _cartRepository.Get(x => x.Token == token)).SingleOrDefault();
            if (cart == null)
                return new DataResultModel<CartSummaryResult>(false, "Cannot find any cart data that belongs this token", null);
            var result = new CartSummaryResult();
            var cartItems = await _cartItemRepository.Get(x => x.CartId == cart.Id);
            result.CartId = cart.Id;
            result.Items = cartItems.ToList();
            foreach (var item in cartItems)
            {

                var product = await _productService.GetById(item.ProductId);
                result.TotalPrice += product.Data.price;
            }
            return new DataResultModel<CartSummaryResult>(true, result);
        }
    }
    
}
