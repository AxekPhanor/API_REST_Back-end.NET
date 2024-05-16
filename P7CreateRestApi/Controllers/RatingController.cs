using Dot.Net.WebApi.Domain;
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
        private readonly ILogger<RatingController> _logger;
        public RatingController(IRatingService ratingService, ILogger<RatingController> logger)
        {
            _ratingService = ratingService;
            _logger = logger;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult Home()
        {
            _logger.LogInformation("Récupération de la liste des 'Rating'");
            try
            {
                return Ok(_ratingService.List());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de la récupération des listes 'Rating'");
                return StatusCode(500, "Une erreur interne s'est produite");
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            _logger.LogInformation("Récupération de la 'Rating' avec l'id : {id}", id);
            try
            {
                var ratingService = _ratingService.Get(id);
                if (ratingService is not null)
                {
                    return Ok(ratingService);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, "Erreur lors de la récupération de la 'Rating' avec l'id : {id}", id);
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddRating([FromBody] RatingInputModel inputModel)
        {
            _logger.LogInformation("Ajout d'une nouvelle 'Rating'");
            try
            {
                _ratingService.Create(inputModel);
                return Ok(inputModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de l'ajout d'une nouvelle 'Rating'");
                return StatusCode(500, "Une erreur interne s'est produite");
            }
        }

        [HttpGet]
        [Route("add")]
        public IActionResult AddRatingForm([FromBody]Rating rating)
        {
            return Ok();
        }

        [HttpGet]
        [Route("update/{id}")]
        public IActionResult ShowUpdateForm(int id)
        {
            _logger.LogInformation("Récupération sur la route 'update/id' de 'Rating' avec l'id : {id}", id);
            try
            {
                var rating = _ratingService.Get(id);
                if (rating is not null)
                {
                    return Ok(rating);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, "Erreur lors de la récupération de 'Rating' avec l'id : {id}", id);
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult UpdateById([FromRoute] int id, [FromBody] RatingInputModel inputModel)
        {
            _logger.LogInformation("Mise à jour de la 'Rating' avec l'id : {id}", id);
            try
            {
                var rating = _ratingService.Update(id, inputModel);
                if (rating is not null)
                {
                    return Ok(_ratingService.List());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, "Erreur lors de la mise à jour de la 'Rating' avec l'id : {id}", id);
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteRating([FromRoute] int id)
        {
            _logger.LogInformation("Suppression de la 'Rating' avec l'id : {id}", id);
            try
            {
                var rating = _ratingService.Delete(id);
                if (rating is not null)
                {
                    return Ok(_ratingService.List());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, "Erreur lors de la suppression de la 'Rating' avec l'id : {id}", id);
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }
    }
}