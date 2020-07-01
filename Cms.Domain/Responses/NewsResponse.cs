using System;
using System.Collections.Generic;
using System.Text;
using Cms.Domain.Entities;

namespace Cms.Domain.Responses
{
    public class NewsResponse
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public Category Category { get; set; }
        public string EncodedText { get; set; }
    }
}
