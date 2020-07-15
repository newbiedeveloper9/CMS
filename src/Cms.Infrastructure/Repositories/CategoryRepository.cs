using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cms.Domain.Entities;
using Cms.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cms.Infrastructure.Repositories
{
    public class CategoryRepository :  ICategoryRepository
    {
        private readonly CmsContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public CategoryRepository(CmsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAsync()
        {
            var categories = await _context.Categories
                .AsNoTracking()
                .ToListAsync();

            return categories;
        }

        public async Task<Category> GetAsync(long id)
        {
            var categories = await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (categories == null) return null;

            _context.Entry(categories).State = EntityState.Detached;
            return categories;
        }

        public Category Add(Category category)
        {
            return _context.Categories.Add(category).Entity;
        }

        public Category Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            return category;
        }

        public Category Delete(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
