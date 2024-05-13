using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Services;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TradeController : ControllerBase
    {
        private readonly ITradeService _tradeService;
        private readonly ILogger<TradeController> _logger;
        public TradeController(ITradeService tradeService, ILogger<TradeController> logger)
        {
            _tradeService = tradeService;
            _logger = logger;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult Home()
        {
            _logger.LogInformation("Récupération de la liste des 'Trade'");
            try
            {
                return Ok(_tradeService.List());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de la récupération des listes 'Trade'");
                return StatusCode(500, "Une erreur interne s'est produite");
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            _logger.LogInformation("Récupération de la 'Trade' avec l'id : {id}", id);
            try
            {
                var trade = _tradeService.Get(id);
                if (trade is not null)
                {
                    return Ok(trade);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, "Erreur lors de la récupération de la 'Trade' avec l'id : {id}", id);
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddTrade([FromBody] TradeInputModel inputModel)
        {
            _logger.LogInformation("Ajout d'une nouvelle 'Trade'");
            try
            {
                _tradeService.Create(inputModel);
                return Ok(inputModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de l'ajout d'une nouvelle 'Trade'");
                return StatusCode(500, "Une erreur interne s'est produite");
            }
        }

        [HttpGet]
        [Route("update/{id}")]
        public IActionResult ShowUpdateForm(int id)
        {
            // TODO: get Trade by Id and to model then show to the form
            return Ok();
        }

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult UpdateById([FromRoute] int id, [FromBody] TradeInputModel inputModel)
        {
            _logger.LogInformation("Mise à jour de la 'Trade' avec l'id : {id}", id);
            try
            {
                var trade = _tradeService.Update(id, inputModel);
                if (trade is not null)
                {
                    return Ok(_tradeService.List());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, "Erreur lors de la mise à jour de la 'Trade' avec l'id : {id}", id);
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteTrade([FromRoute] int id)
        {
            _logger.LogInformation("Suppression de la 'Trade' avec l'id : {id}", id);
            try
            {
                var trade = _tradeService.Delete(id);
                if (trade is not null)
                {
                    return Ok(_tradeService.List());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, "Erreur lors de la suppression de la 'Trade' avec l'id : {id}", id);
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }
    }
}