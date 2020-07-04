using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Cms.Domain.Entities;
using Cms.Domain.Mappers;
using Cms.Domain.Repositories;
using Cms.Domain.Requests.News;
using Cms.Domain.Services.News;
using Cms.Domain.UnitTests.Helpers;
using FluentAssertions;
using Moq;
using Xunit;

namespace Cms.Domain.UnitTests.Services
{
    public class NewsServiceTests
    {
        private readonly IMapper _mapper;
        public NewsServiceTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CmsProfile());
            });
            _mapper = config.CreateMapper();
        }

        [Theory, DefaultTestData]
        public async Task GetNewsById_NotFound_ReturnsEmpty(Mock<INewsRepository> newsRepository,
            GetNewsRequest getRequest)
        {
            newsRepository.Setup(x => x.GetAsync(It.IsAny<long>())).ReturnsAsync((News) null);
            var service = new NewsService(newsRepository.Object, _mapper);

            var result = await service.GetNewsAsync(getRequest);

            result.Should().BeNull();
            newsRepository.Verify(x=>x.GetAsync(It.IsAny<long>()), Times.Once);
            newsRepository.VerifyNoOtherCalls();
        }

        [Theory, DefaultTestData]
        public async Task GetNewsById_FoundItem_ReturnsTheObject(Mock<INewsRepository> newsRepository,
            GetNewsRequest getRequest,
            News news)
        {
            newsRepository.Setup(x => x.GetAsync(It.IsAny<long>())).ReturnsAsync(news);
            var service = new NewsService(newsRepository.Object, _mapper);

            var actual = await service.GetNewsAsync(getRequest);

            actual.Category.Should().NotBeNull();
            actual.EncodedText.Should().NotBeNullOrEmpty();
            actual.Slug.Should().NotBeNullOrEmpty();
            actual.Title.Should().NotBeNullOrEmpty();

            newsRepository.Verify(x => x.GetAsync(It.IsAny<long>()), Times.Once);
            newsRepository.VerifyNoOtherCalls();
        }

        [Theory, DefaultTestData]
        public async Task AddNews_NewsValid_ReturnsNotNull(Mock<INewsRepository> newsRepository,
            News news,
            AddNewsRequest addRequest)
        {
            newsRepository.Setup(x => x.Add(It.IsAny<News>())).Returns(news);
            var service = new NewsService(newsRepository.Object, _mapper);

            var actual = await service.AddNewsAsync(addRequest);

            actual.Category.Should().NotBeNull();
            actual.EncodedText.Should().NotBeNullOrEmpty();
            actual.Slug.Should().NotBeNullOrEmpty();
            actual.Title.Should().NotBeNullOrEmpty();

            newsRepository.Verify(x => x.Add(It.IsAny<News>()), Times.Once);
            newsRepository.Verify(x=>
                x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
            newsRepository.VerifyNoOtherCalls();
        }

        //TODO Update and Get methods have to be tested
    }

    public class NewsServiceExceptions
    {
        private readonly IMapper _mapper;
        public NewsServiceExceptions()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CmsProfile());
            });
            _mapper = config.CreateMapper();
        }

        [Theory, DefaultTestData]
        public async Task AddNews_NullRequest_ReturnsNullException(Mock<INewsRepository> newsRepository)
        {
            var service = new NewsService(newsRepository.Object, _mapper);

            async Task Actual() => await service.AddNewsAsync(null);

            await Assert.ThrowsAsync<ArgumentNullException>(Actual);
            newsRepository.VerifyNoOtherCalls();
        }

        [Theory, DefaultTestData]
        public async Task UpdateNews_NullRequest_ReturnsNullException(Mock<INewsRepository> newsRepository)
        {
            var service = new NewsService(newsRepository.Object, _mapper);

            async Task Actual() => await service.EditNewsAsync(null);

            await Assert.ThrowsAsync<ArgumentNullException>(Actual);
            newsRepository.VerifyNoOtherCalls();
        }

        [Theory, DefaultTestData]
        public async Task GetNews_NullRequest_ReturnsNullException(Mock<INewsRepository> newsRepository)
        {
            var service = new NewsService(newsRepository.Object, _mapper);

            async Task Actual() => await service.GetNewsAsync(null);

            await Assert.ThrowsAsync<ArgumentNullException>(Actual);
            newsRepository.VerifyNoOtherCalls();
        }
    }
}
