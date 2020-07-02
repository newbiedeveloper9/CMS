using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cms.Domain.Requests.News;
using Cms.Domain.Services.News;
using Microsoft.AspNetCore.Mvc;

namespace Cms.API.Controllers
{
    [ApiController]
    [Route("news")]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _newsService.GetNewsAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(GetNewsRequest request)
        {
            var result = await _newsService.GetNewsAsync(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddNewsRequest request)
        {
            var result = await _newsService.AddNewsAsync(request);
            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> Update(EditNewsRequest request)
        {
            var result = await _newsService.EditNewsAsync(request);
            return Ok(result);
        }
    }
}
