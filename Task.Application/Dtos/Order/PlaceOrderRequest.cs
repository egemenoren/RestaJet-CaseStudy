namespace CaseStudy.Application.Dtos.Order
{
    public class PlaceOrderRequest
    {
        public string Token { get; set; }
        public Location CustomerLocation { get; set; }
        public List<Location> DeliveryArea { get; set; }
    }
}
