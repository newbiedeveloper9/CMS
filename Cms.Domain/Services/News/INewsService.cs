using System.Collections.Generic;
using System.Threading.Tasks;
using Cms.Domain.Requests.News;
using Cms.Domain.Responses;

namespace Cms.Domain.Services.News
{
    public interface INewsService
    {
        Task<IEnumerable<NewsResponse>> GetNewsAsync();
        Task<NewsResponse> GetNewsAsync(GetNewsRequest request);
        Task<NewsResponse> AddNewsAsync(AddNewsRequest request);
        Task<NewsResponse> EditNewsAsync(EditNewsRequest request);

    }
}