using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Domain.Requests.News
{
    public class GetNewsRequest
    {
        public long Id { get; set; }

        public GetNewsRequest(long id)
        {
            Id = id;
        }
    }
}
