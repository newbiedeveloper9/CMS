using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cms.Domain.Repositories;
using Cms.Domain.Requests.Category;
using Cms.Domain.Responses;

namespace Cms.Domain.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly INewsRepository _newsRepository;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository, INewsRepository newsRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _newsRepository = newsRepository;
        }

        public async Task<IEnumerable<CategoryResponse>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAsync();
            var response = _mapper.Map<IEnumerable<CategoryResponse>>(categories);
            return response;
        }

        public async Task<CategoryResponse> GetCategoryAsync(GetCategoryRequest request)
        {
            if(request == null) throw new ArgumentNullException();

            var category = await _categoryRepository.GetAsync(request.Id);
            var response = _mapper.Map<CategoryResponse>(category);

            return response;
        }

        public async Task<IEnumerable<NewsResponse>> GetNewsByCategoryIdAsync(GetCategoryRequest request)
        {
            if (request == null) throw new ArgumentNullException();

            var news = await _newsRepository.GetNewsByCategoryIdAsync(request.Id);
            var response = _mapper.Map<IEnumerable<NewsResponse>>(news);

            return response;
        }

        public async Task<CategoryResponse> AddCategoryAsync(AddCategoryRequest request)
        {
            if(request == null) throw new ArgumentNullException();
            var category = _mapper.Map<Entities.Category>(request);

            var result = _categoryRepository.Add(category);
            await _categoryRepository.UnitOfWork.SaveChangesAsync();

            var response = _mapper.Map<CategoryResponse>(result);
            return response;
        }

        public async Task<CategoryResponse> EditCategoryAsync(EditCategoryRequest request)
        {
            if(request == null) throw new ArgumentNullException();
            
            var categoryExists = await _categoryRepository.GetAsync(request.Id);
            if (categoryExists == null) 
                throw new ArgumentException("News with id {request.Id} does not exist");

            var category = _mapper.Map<Entities.Category>(request);
            var result = _categoryRepository.Update(category);
            await _categoryRepository.UnitOfWork.SaveChangesAsync();

            var response = _mapper.Map<CategoryResponse>(result);
            return response;
        }
    }
}
