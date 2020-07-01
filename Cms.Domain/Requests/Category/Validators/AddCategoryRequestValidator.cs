using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Cms.Domain.Requests.Category.Validators
{
    public class AddCategoryRequestValidator : AbstractValidator<AddCategoryRequest>
    {
        public AddCategoryRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
