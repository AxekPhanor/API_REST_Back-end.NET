using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Services;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BidListController : ControllerBase
    {
        private readonly IBidListService _bidListService;
        public BidListController(IBidListService bidListService) 
        { 
            _bidListService = bidListService;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {
            return Ok(_bidListService.List());
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var bidList = _bidListService.Get(id);
            if(bidList is not null)
            {
                return Ok(bidList);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddBidList([FromBody] BidListInputModel inputModel)
        {
            _bidListService.Create(inputModel);
            return Ok(inputModel);
        }

        [HttpGet]
        [Route("validate")]
        public IActionResult Validate([FromBody] BidList bidList)
        {
            // TODO: check data valid and save to db, after saving return bid list
            return Ok();
        }

        [HttpGet]
        [Route("update/{id}")]
        public IActionResult ShowUpdateForm(int id)
        {
            return Ok();
        }

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult UpdateById(int id, [FromBody] BidListInputModel inputModel)
        {
            var bidList = _bidListService.Update(id, inputModel);
            if(bidList is not null)
            {
                return Ok(_bidListService.List());
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteById(int id)
        {
            var bidList = _bidListService.Delete(id);
            if (bidList is not null)
            {
                return Ok(_bidListService.List());
            }
            return NotFound();
        }
    }
}