using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Services;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RuleNameController : ControllerBase
    {
        private readonly IRuleNameService _ruleNameService;
        private readonly ILogger<RuleNameController> _logger;
        public RuleNameController(IRuleNameService ruleNameService, ILogger<RuleNameController> logger)
        {
            _ruleNameService = ruleNameService;
            _logger = logger;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult Home()
        {
            _logger.LogInformation("Récupération de la liste des 'RuleName'");
            try
            {
                return Ok(_ruleNameService.List());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de la récupération des listes 'RuleName'");
                return StatusCode(500, "Une erreur interne s'est produite");
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            _logger.LogInformation("Récupération de la 'RuleName' avec l'id : {id}", id);
            try
            {
                var ruleName = _ruleNameService.Get(id);
                if (ruleName is not null)
                {
                    return Ok(ruleName);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, "Erreur lors de la récupération de la 'RuleName' avec l'id : {id}", id);
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddRuleName([FromBody] RuleNameInputModel inputModel)
        {
            _logger.LogInformation("Ajout d'une nouvelle 'RuleName'");
            try
            {
                _ruleNameService.Create(inputModel);
                return Ok(inputModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de l'ajout d'une nouvelle 'RuleName'");
                return StatusCode(500, "Une erreur interne s'est produite");
            }
        }

        [HttpGet]
        [Route("validate")]
        public IActionResult Validate([FromBody]RuleName trade)
        {
            // TODO: check data valid and save to db, after saving return RuleName list
            return Ok();
        }

        [HttpGet]
        [Route("update/{id}")]
        public IActionResult ShowUpdateForm(int id)
        {
            // TODO: get RuleName by Id and to model then show to the form
            return Ok();
        }

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult UpdateById([FromRoute] int id, [FromBody] RuleNameInputModel inputModel)
        {
            _logger.LogInformation("Mise à jour de la 'RuleName' avec l'id : {id}", id);
            try
            {
                var ruleName = _ruleNameService.Update(id, inputModel);
                if (ruleName is not null)
                {
                    return Ok(_ruleNameService.List());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, "Erreur lors de la mise à jour de la 'RuleName' avec l'id : {id}", id);
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteRuleName([FromRoute] int id)
        {
            _logger.LogInformation("Suppression de la 'RuleName' avec l'id : {id}", id);
            try
            {
                var ruleName = _ruleNameService.Delete(id);
                if (ruleName is not null)
                {
                    return Ok(_ruleNameService.List());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, "Erreur lors de la suppression de la 'RuleName' avec l'id : {id}", id);
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }
    }
}