using System.Threading;
using System.Threading.Tasks;
using Cms.Domain.Requests.Category;
using Cms.Domain.Services.Category;
using FluentValidation;

namespace Cms.Domain.Requests.News.Validators
{
    public class AddNewsRequestValidator : AbstractValidator<AddNewsRequest>
    {
        private readonly ICategoryService _categoryService;

        public AddNewsRequestValidator(ICategoryService categoryService)
        {
            _categoryService = categoryService;

            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .MustAsync(CategoryExists).WithMessage("Given category does not exists");
            RuleFor(x => x.EncodedText).NotEmpty();
            RuleFor(x => x.Slug).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
        }

        private async Task<bool> CategoryExists(int Id, CancellationToken cancellationToken)
        {
            var getCategory = new GetCategoryRequest(Id);
            var category = await _categoryService.GetCategoryAsync(getCategory);

            return category != null;
        }
    }
}
