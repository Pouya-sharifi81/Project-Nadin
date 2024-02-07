using FluentValidation;
using Nadin_Domain.Models.Pruducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadin_Domain.Validator.ProductValidator
{
    public class ProductValid : AbstractValidator<Product>
    {
        public ProductValid()
        {
            RuleFor(p => p.Email)
          .NotNull().WithMessage("email content can't be null")
          .NotEmpty().WithMessage("Pemail content can't be empty")
           .MinimumLength(3).WithMessage("Last name must be at least 3 characters long")
           .MaximumLength(50).WithMessage("Last name can contain at most 50 characters long");
            RuleFor(p => p.Name)
         .NotNull().WithMessage("name content can't be null")
         .NotEmpty().WithMessage("name content can't be empty")
          .MinimumLength(3).WithMessage("Last name must be at least 3 characters long")
          .MaximumLength(50).WithMessage("Last name can contain at most 50 characters long");
        }
    }
}
