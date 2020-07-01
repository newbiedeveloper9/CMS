using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Domain.Requests.Category
{
    public class EditCategoryRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
