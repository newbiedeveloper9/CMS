using FluentValidation;

namespace Cms.Domain.Requests.Category.Validators
{
    public class EditCategoryRequestValidator : AbstractValidator<EditCategoryRequest>
    {
        public EditCategoryRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x).NotEmpty();
        }
    }
}