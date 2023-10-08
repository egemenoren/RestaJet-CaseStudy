using CaseStudy.Application.Dtos.Cart;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Application.Validation.CartItem
{
    public class UpdateCartItemValidator:AbstractValidator<UpdateCartItemQuantityRequest>
    {
        public UpdateCartItemValidator()
        {
            RuleFor(x => x.Quantity).GreaterThan((byte)0);
            RuleFor(x => x.ProductId).GreaterThan(0);
            RuleFor(x => x.Token).NotEmpty().Length(36);
        }
    }
}
