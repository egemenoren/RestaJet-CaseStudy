using AutoMapper;
using CaseStudy.Application.CQRS;
using CaseStudy.Application.Dtos.Cart;
using CaseStudy.Core.Entities;

namespace CaseStudy.Presentation.Mapping
{
    public class CartMapping:Profile
    {
        public CartMapping()
        {
            CreateCartCommandMap();
            CreateCartResponseMap();
            AddItemToCartRequestMap();
            DeleteCartItemRequestMap();
            GetCartSummaryRequestMap();
        }
        private void CreateCartCommandMap()
        {
            var map = CreateMap<CreateCartRequest, CreateCartCommand>();
        }
        private void CreateCartResponseMap()
        {
            var map = CreateMap<Cart, CreateCartResponse>();
        }
        private void AddItemToCartRequestMap()
        {
            var map = CreateMap<AddItemToCartRequest, AddCartItemCommand>();
        }
        private void DeleteCartItemRequestMap()
        {
            var map = CreateMap<DeleteCartItemRequest, DeleteCartItemCommand>();
        }
        private void GetCartSummaryRequestMap()
        {
            var map = CreateMap<GetCartSummaryRequest, GetCartSummaryQuery>();
        }
    }
}
