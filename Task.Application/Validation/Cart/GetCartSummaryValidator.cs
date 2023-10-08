using CaseStudy.Application.Dtos.Cart;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Application.Validation.Cart
{
    public class GetCartSummaryValidator:AbstractValidator<GetCartSummaryRequest>
    {
        public GetCartSummaryValidator()
        {
            RuleFor(x => x.Token).Length(36);
        }
    }
}
