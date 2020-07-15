using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Cms.Domain.Entities;
using Cms.Domain.Requests.Category;
using Cms.Domain.Requests.News;
using Cms.Domain.Responses;

namespace Cms.Domain.Mappers
{
    public class CmsProfile : Profile
    {
        public CmsProfile()
        {
            CreateMap<NewsResponse, News>().ReverseMap();
            CreateMap<AddNewsRequest, News>().ReverseMap();
            CreateMap<EditNewsRequest, News>().ReverseMap();
            CreateMap<GetNewsRequest, News>().ReverseMap();


            CreateMap<AddCategoryRequest, Category>().ReverseMap();
            CreateMap<EditCategoryRequest, Category>().ReverseMap();
            CreateMap<GetCategoryRequest, Category>().ReverseMap();
            CreateMap<CategoryResponse, Category>().ReverseMap();
        }
    }
}
