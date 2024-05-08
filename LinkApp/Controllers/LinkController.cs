using LinkApp.DTO;
using LinkApp.Models;
using LinkApp.Response;
using LinkApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkApp.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class LinkController : ControllerBase
    {

        private LinkService _linkService;
        public LinkController(LinkService linkService)
        {
            _linkService = linkService;
        }
        [HttpGet("{id}")]
        public IActionResult GetByLink(int id)
        {
            var link = _linkService.FindById(id);
            if (link == null)
                return NotFound(new ResponseMessage { Message = "Böyle Bir Link Yok" });
            return Ok(new LinkDTO { Link = link.LinkUrl });
        }

        [HttpPost]
        public IActionResult AddLink(LinkDTO linkDTO)
        {

            long id = _linkService.Save(new Link
            {
                LinkUrl = linkDTO.Link
            });

            return Ok(new AddLinkResponse { SavedId = id });
        }
    }
}
