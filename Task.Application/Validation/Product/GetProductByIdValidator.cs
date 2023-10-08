using CaseStudy.Application.Dtos.Product;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Application.Validation.Product
{
    public class GetProductByIdValidator:AbstractValidator<GetProductByIdRequest>
    {
        public GetProductByIdValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
