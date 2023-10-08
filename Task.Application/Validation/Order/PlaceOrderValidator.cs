using CaseStudy.Application.Dtos;
using CaseStudy.Application.Dtos.Order;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Application.Validation.Order
{
    public class PlaceOrderValidator:AbstractValidator<PlaceOrderRequest>
    {
        public PlaceOrderValidator()
        {
            RuleFor(x => x.Token).Length(36);
            RuleFor(x => x).Must(x => IsInDeliveryArea(x.CustomerLocation, x.DeliveryArea)).WithMessage("You are not in the delivery zone. Please Try again later.").WithName("DeliveryZone");
        }
        private bool IsInDeliveryArea(Location customerLocation, List<Location> deliveryArea)
        {
            int count = deliveryArea.Count;
            bool isInDeliveryArea = false;

            for (int i = 0, j = count - 1; i < count; j = i++)
            {
                if (((deliveryArea[i].Longitude > customerLocation.Longitude) != (deliveryArea[j].Longitude > customerLocation.Longitude)) &&
                    (customerLocation.Latitude < (deliveryArea[j].Latitude - deliveryArea[i].Latitude) * (customerLocation.Longitude - deliveryArea[i].Longitude / (deliveryArea[j].Longitude - deliveryArea[i].Longitude) + deliveryArea[i].Latitude)))
                {
                    isInDeliveryArea = !isInDeliveryArea;
                }
            }
            return isInDeliveryArea;
        }
    }
}
