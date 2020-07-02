using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Cms.Domain.Entities;

namespace Cms.Domain.Requests.News
{
    public class AddNewsRequest
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public int CategoryId { get; set; }
        public string EncodedText { get; set; }
    }
}
