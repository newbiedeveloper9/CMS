using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Domain.Entities
{
    public class News
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }

    }
}
