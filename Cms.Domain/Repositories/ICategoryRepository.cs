using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cms.Domain.Entities;

namespace Cms.Domain.Repositories
{
    public interface ICategoryRepository : IRepository
    {
        Task<IEnumerable<Category>> GetAsync();
        Task<Category> GetAsync(long id);
        Category Add(Category category);
        Category Update(Category category);
        Category Delete(Category category);
    }
}