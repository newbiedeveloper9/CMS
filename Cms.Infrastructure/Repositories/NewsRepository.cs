using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cms.Domain.Entities;
using Cms.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cms.Infrastructure.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly CmsContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public NewsRepository(CmsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<News>> GetAsync()
        {
            var news = await _context.News
                .AsNoTracking()
                .ToListAsync();

            return news;
        }

        public async Task<News> GetAsync(long id)
        {
            var news = await _context.News
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (news == null) return null;

            _context.Entry(news).State = EntityState.Detached;
            return news;
        }

        public async Task<IEnumerable<News>> GetNewsByCategoryIdAsync(int categoryId)
        {
            var news = await _context.News
                .AsNoTracking()
                .Where(x => x.CategoryId == categoryId)
                .Include(x => x.Category)
                .ToListAsync();

            return news;
        }

        public News Add(News news)
        {
            return _context.News.Add(news).Entity;
        }

        public News Update(News news)
        {
            _context.Entry(news).State = EntityState.Modified;
            return news;
        }

        public News Delete(News news)
        {
            throw new NotImplementedException();
        }
    }
}
