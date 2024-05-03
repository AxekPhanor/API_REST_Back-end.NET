using Dot.Net.WebApi.Controllers.Domain;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Services;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;
        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult Home()
        {
            return Ok(_ratingService.List());
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var ratingService = _ratingService.Get(id);
            if (ratingService is not null)
            {
                return Ok(ratingService);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddRating([FromBody] RatingInputModel inputModel)
        {
            _ratingService.Create(inputModel);
            return Ok(inputModel);
        }

        [HttpGet]
        [Route("add")]
        public IActionResult AddRatingForm([FromBody]Rating rating)
        {
            return Ok();
        }

        [HttpGet]
        [Route("validate")]
        public IActionResult Validate([FromBody]Rating rating)
        {
            // TODO: check data valid and save to db, after saving return Rating list
            return Ok();
        }

        [HttpGet]
        [Route("update/{id}")]
        public IActionResult ShowUpdateForm(int id)
        {
            // TODO: get Rating by Id and to model then show to the form
            return Ok();
        }

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult UpdateById([FromRoute] int id, [FromBody] RatingInputModel inputModel)
        {
            var rating = _ratingService.Update(id, inputModel);
            if (rating is not null)
            {
                return Ok(_ratingService.List());
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteRating([FromRoute] int id)
        {
            var rating = _ratingService.Delete(id);
            if (rating is not null)
            {
                return Ok(_ratingService.List());
            }
            return NotFound();
        }
    }
}