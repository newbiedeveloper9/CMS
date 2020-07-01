using System.Collections.Generic;
using System.Threading.Tasks;
using Cms.Domain.Entities;

namespace Cms.Domain.Repositories
{
    public interface INewsRepository : IRepository
    {
        Task<IEnumerable<News>> GetAsync();
        Task<News> GetAsync(long id);
        Task<IEnumerable<News>> GetNewsByCategoryIdAsync(int categoryId);
        News Add(News news);
        News Update(News news);
        News Delete(News news);
    }
}
