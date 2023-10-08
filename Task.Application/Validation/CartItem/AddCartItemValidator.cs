using CaseStudy.Application.CQRS;
using CaseStudy.Application.Dtos.Cart;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Application.Validation
{
    public class AddCartItemValidator:AbstractValidator<AddItemToCartRequest>
    {
        public AddCartItemValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Token).NotEmpty().Length(36);
        }
    }
}
