using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Services;
using Serilog;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RuleNameController : ControllerBase
    {
        private readonly IRuleNameService _ruleNameService;
        public RuleNameController(IRuleNameService ruleNameService)
        {
            _ruleNameService = ruleNameService;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult Home()
        {
            Log.Information("R�cup�ration de la liste des 'RuleName'");
            try
            {
                return Ok(_ruleNameService.List());
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur lors de la r�cup�ration des listes 'RuleName'");
                return StatusCode(500, "Une erreur interne s'est produite");
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            Log.Information("R�cup�ration de 'RuleName' avec l'id : {id}", id);
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
                Log.Error(ex, "Erreur lors de la r�cup�ration de 'RuleName' avec l'id : {id}", id);
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddRuleName([FromBody] RuleNameInputModel inputModel)
        {
            Log.Information("Ajout d'une nouvelle 'RuleName'");
            try
            {
                _ruleNameService.Create(inputModel);
                return Ok(inputModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur lors de l'ajout d'une nouvelle 'RuleName'");
                return StatusCode(500, "Une erreur interne s'est produite");
            }
        }

        [HttpGet]
        [Route("update/{id}")]
        public IActionResult ShowUpdateForm(int id)
        {
            Log.Information("R�cup�ration sur la route 'update/id' de 'RuleName' avec l'id : {id}", id);
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
                Log.Error(ex, "Erreur lors de la r�cup�ration de 'RuleName' avec l'id : {id}", id);
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult UpdateById([FromRoute] int id, [FromBody] RuleNameInputModel inputModel)
        {
            Log.Information("Mise � jour de 'RuleName' avec l'id : {id}", id);
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
                Log.Error(ex, "Erreur lors de la mise � jour de 'RuleName' avec l'id : {id}", id);
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteRuleName([FromRoute] int id)
        {
            Log.Information("Suppression de 'RuleName' avec l'id : {id}", id);
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
                Log.Error(ex, "Erreur lors de la suppression de 'RuleName' avec l'id : {id}", id);
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }
    }
}