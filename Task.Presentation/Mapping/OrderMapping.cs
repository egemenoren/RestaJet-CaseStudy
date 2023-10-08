using AutoMapper;
using CaseStudy.Application.CQRS;
using CaseStudy.Application.Dtos.Order;

namespace CaseStudy.Presentation.Mapping
{
    public class OrderMapping:Profile
    {
        public OrderMapping()
        {
            PlaceOrderRequestMap();
        }
        private void PlaceOrderRequestMap()
        {
            var map = CreateMap<PlaceOrderRequest, PlaceOrderCommand>();
        }
    }
}
