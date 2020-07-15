using System.Collections.Generic;
using System.Threading.Tasks;
using Cms.Domain.Requests.Category;
using Cms.Domain.Responses;

namespace Cms.Domain.Services.Category
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponse>> GetCategoriesAsync();
        Task<CategoryResponse> GetCategoryAsync(GetCategoryRequest request);
        Task<IEnumerable<NewsResponse>> GetNewsByCategoryIdAsync(GetCategoryRequest request);
        Task<CategoryResponse> AddCategoryAsync(AddCategoryRequest request);
        Task<CategoryResponse> EditCategoryAsync(EditCategoryRequest request);
    }
}