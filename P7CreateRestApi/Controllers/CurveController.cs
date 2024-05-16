using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Services;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurveController : ControllerBase
    {
        private readonly ICurvePointService _curvePointService;
        private readonly ILogger<CurveController> _logger;

        public CurveController(ICurvePointService curvePointService, ILogger<CurveController> logger)
        {
            _curvePointService = curvePointService;
            _logger = logger;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult Home()
        {
            _logger.LogInformation("Récupération de la liste des 'Curve'");
            try
            {
                return Ok(_curvePointService.List());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération de la liste des 'Curve'");
                return StatusCode(500, "Une erreur interne s'est produite");
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            _logger.LogInformation("Récupération de la 'Curve' avec l'id : {id}", id);
            try
            {
                var curvePoint = _curvePointService.Get(id);
                if (curvePoint is not null)
                {
                    return Ok(curvePoint);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, "Erreur lors de la récupération de la 'Curve' avec l'id : {id}", id);
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddCurvePoint([FromBody] CurvePointInputModel inputModel)
        {
            _logger.LogInformation("Ajout d'une nouvelle 'Curve'");
            try
            {
                _curvePointService.Create(inputModel);
                return Ok(inputModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur s'est produite lors de l'ajout d'une nouvelle 'Curve'");
                return StatusCode(500, "Une erreur interne s'est produite");
            }
        }

        [HttpGet]
        [Route("update/{id}")]
        public IActionResult ShowUpdateForm(int id)
        {
            _logger.LogInformation("Récupération sur la route 'update/id' de 'Curve' avec l'id : {id}", id);
            try
            {
                var curvePoint = _curvePointService.Get(id);
                if (curvePoint is not null)
                {
                    return Ok(curvePoint);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, "Erreur lors de la récupération de 'Curve' avec l'id : {id}", id);
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult UpdateById([FromRoute] int id, [FromBody] CurvePointInputModel inputModel)
        {
            _logger.LogInformation("Mise à jour de la 'Curve' avec l'id : {id}", id);
            try
            {
                var curvePoint = _curvePointService.Update(id, inputModel);
                if (curvePoint is not null)
                {
                    return Ok(_curvePointService.List());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, "Erreur lors de la mise à jour de la 'Curve' avec l'id : {id}", id);
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
            
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteById(int id)
        {
            _logger.LogInformation("Suppression de la 'Curve' avec l'id : {id}", id);
            try
            {
                var curvePoint = _curvePointService.Delete(id);
                if (curvePoint is not null)
                {
                    return Ok(_curvePointService.List());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, "Erreur lors de la suppression de la 'Curve' avec l'id : {id}", id);
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }
    }
}