using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Cms.Domain.Requests.Category;
using Cms.Domain.Services.Category;
using Microsoft.AspNetCore.Mvc;

namespace Cms.API.Controllers
{
    [Route("category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _categoryService.GetCategoriesAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(GetCategoryRequest request)
        {
            var result = await _categoryService.GetCategoryAsync(request);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("{id:int}/news")]
        public async Task<IActionResult> GetNewsById(GetCategoryRequest request)
        {
            var result = await _categoryService.GetNewsByCategoryIdAsync(request);
            if (!result.Any())
                NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddCategoryRequest request)
        {
            var result = await _categoryService.AddCategoryAsync(request);
            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> Update(EditCategoryRequest request)
        {
            var result = await _categoryService.EditCategoryAsync(request);
            return Ok(result);
        }
    }
}
