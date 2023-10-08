using CaseStudy.Application.Dtos.Product;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Application.Validation.Product
{
    public class GetAllProductsValidator:AbstractValidator<GetAllProductsRequest>
    {
        public GetAllProductsValidator()
        {
            RuleFor(x => x.Limit).GreaterThan(1);
            RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(0);
        }
    }
}
