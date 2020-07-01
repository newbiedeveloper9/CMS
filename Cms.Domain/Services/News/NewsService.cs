using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cms.Domain.Repositories;
using Cms.Domain.Requests.News;
using Cms.Domain.Responses;

namespace Cms.Domain.Services.News
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;

        public NewsService(INewsRepository newsRepository, IMapper mapper)
        {
            _newsRepository = newsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NewsResponse>> GetNewsAsync()
        {
            var news = await _newsRepository.GetAsync();
            var response = _mapper.Map<IEnumerable<NewsResponse>>(news);

            return response;
        }

        public async Task<NewsResponse> GetNewsAsync(GetNewsRequest request)
        {
            if(request == null) throw new ArgumentNullException();

            var news = await _newsRepository.GetAsync(request.Id);
            var response = _mapper.Map<NewsResponse>(news);

            return response;
        }

        public async Task<NewsResponse> AddNewsAsync(AddNewsRequest request)
        {
            if(request == null) throw new ArgumentNullException();
            var news = _mapper.Map<Entities.News>(request);

            var result = _newsRepository.Add(news);
            await _newsRepository.UnitOfWork.SaveChangesAsync();

            var response = _mapper.Map<NewsResponse>(result);
            return response;
        }

        public async Task<NewsResponse> EditNewsAsync(EditNewsRequest request)
        {
            if(request == null) throw new ArgumentNullException();

            var newsExists = await _newsRepository.GetAsync(request.Id);
            if(newsExists == null) 
                throw new ArgumentException($"News with id {request.Id} does not exist");

            var news = _mapper.Map<Entities.News>(request);
            var result = _newsRepository.Update(news);
            await _newsRepository.UnitOfWork.SaveChangesAsync();

            var response = _mapper.Map<NewsResponse>(result);
            return response;
        }
    }
}
