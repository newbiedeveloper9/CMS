using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Domain.Requests.Category
{
    public class GetCategoryRequest
    {
        public int Id { get; set; }

        public GetCategoryRequest(int id)
        {
            Id = id;
        }
    }
}
