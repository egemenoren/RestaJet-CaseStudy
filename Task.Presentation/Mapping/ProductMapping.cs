using AutoMapper;
using CaseStudy.Application.CQRS;
using CaseStudy.Application.CQRS.Product;
using CaseStudy.Application.Dtos.Cart;
using CaseStudy.Application.Dtos.Product;

namespace CaseStudy.Presentation.Mapping
{
    public class ProductMapping:Profile
    {
        public ProductMapping()
        {
            GetProductByIdRequestMap();
            GetAllProductsRequestMap();
            UpdateCartItemQuantityRequestMap();
        }
        private void GetProductByIdRequestMap()
        {
            var map = CreateMap<GetProductByIdRequest, GetProductByIdQuery>();
        }
        private void GetAllProductsRequestMap()
        {
            var map = CreateMap<GetAllProductsRequest, GetProductListQuery>();
            map.ForMember(dest => dest.limit, c => c.MapFrom(src => src.Limit));
            map.ForMember(dest => dest.skip, c => c.MapFrom(src => src.PageIndex * src.Limit));
        }
        private void UpdateCartItemQuantityRequestMap()
        {
            var map = CreateMap<UpdateCartItemQuantityRequest, UpdateCartItemQuantityCommand>();
        }
    }
}
