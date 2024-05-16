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
        private readonly ILogger<BidListController> _logger;
        public BidListController(IBidListService bidListService, ILogger<BidListController> logger) 
        { 
            _bidListService = bidListService;
            _logger = logger;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {
            try
            {
                _logger.LogInformation("Récupération de la liste des 'BidList'");
                return Ok(_bidListService.List());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération de la liste des 'BidList'");
                return StatusCode(500, "Une erreur interne s'est produite");
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            _logger.LogInformation("Récupération de 'BidList' avec l'id : {id}", id);
            try
            {
                var bidList = _bidListService.Get(id);
                if (bidList is not null)
                {
                    return Ok(bidList);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, "Erreur lors de la récupération de 'BidList avec l'id : {id}'", id);
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddBidList([FromBody] BidListInputModel inputModel)
        {
            _logger.LogInformation("Ajout d'une nouvelle 'BidList'");
            try
            {
                _bidListService.Create(inputModel);
                return Ok(inputModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, "Erreur lors de l'ajout d'une nouvelle 'BidList'");
                return StatusCode(500, "Une erreur interne s'est produite");
            }
        }

        [HttpGet]
        [Route("update/{id}")]
        public IActionResult ShowUpdateForm(int id)
        {
            _logger.LogInformation("Récupération sur la route 'update/id' de 'BidList' avec l'id : {id}", id);

            try
            {
                var bidList = _bidListService.Get(id);
                if (bidList is not null)
                {
                    return Ok(bidList);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, "Erreur lors de la récupération de 'BidList' avec l'id : {id}", id);
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult UpdateById([FromRoute] int id, [FromBody] BidListInputModel inputModel)
        {
            _logger.LogInformation("Mise à jour de 'BidList' avec l'id : {id}", id);
            try
            {
                var bidList = _bidListService.Update(id, inputModel);
                if (bidList is not null)
                {
                    return Ok(_bidListService.List());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, "Erreur lors de la mise à jour de 'BidList avec l'id : {id}'", id);
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteById([FromRoute] int id)
        {
            _logger.LogInformation("Suppression de 'BidList' avec l'id : {id}", id);
            try
            {
                var bidList = _bidListService.Delete(id);
                if (bidList is not null)
                {
                    return Ok(_bidListService.List());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, "Erreur lors de la suppression de 'BidList avec l'id : {id}'", id);
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }
    }
}