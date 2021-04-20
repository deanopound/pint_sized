using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PintSized.Api.Models;
using PintSized.Api.Models.Request;
using PintSized.Api.Models.Response;
using PintSized.Api.Services;

namespace PintSized.Api.Controllers.V1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ShortURLController : ControllerBase
    {
        private IShortURLService _shortUrlService;
        private readonly ILogger<ShortURLController> _logger;
        public ShortURLController(IShortURLService shortUrlService, ILogger<ShortURLController> logger)
        {
            _shortUrlService = shortUrlService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<ShortURLModel> shortUrls = _shortUrlService.GetCollectionFromDataStore();

            return Ok(shortUrls);
        }

        [HttpGet("{shorturl}", Name = "Get")]
        public IActionResult Get(string shorturl, [FromQuery(Name = "redirect")] bool redirect = true)
        {
            ShortURLModel shortUrl = _shortUrlService.GetItemFromDataStore(shorturl);

            if (shortUrl != null)
            {
                if(redirect)
                {
                    return Redirect(shortUrl.LongURL);
                }
                else
                {
                    return Ok(shortUrl);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] ShortURLRequest model)
        {
            if(ModelState.IsValid)
            {
                ShortURLResponse result = _shortUrlService.SaveItemToDataStore(model);

                if (result != null)
                {
                    return Ok(result);
                }
            }

            return BadRequest(ModelState.Values);
        }
    }
}