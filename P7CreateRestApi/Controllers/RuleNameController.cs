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
        public RuleNameController(IRuleNameService ruleNameService)
        {
            _ruleNameService = ruleNameService;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult Home()
        {
            return Ok(_ruleNameService.List());
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var ruleName = _ruleNameService.Get(id);
            if (ruleName is not null)
            {
                return Ok(ruleName);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddRuleName([FromBody] RuleNameInputModel inputModel)
        {
            _ruleNameService.Create(inputModel);
            return Ok(inputModel);
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
            var ruleName = _ruleNameService.Update(id, inputModel);
            if (ruleName is not null)
            {
                return Ok(_ruleNameService.List());
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteRuleName([FromRoute] int id)
        {
            var ruleName = _ruleNameService.Delete(id);
            if (ruleName is not null)
            {
                return Ok(_ruleNameService.List());
            }
            return NotFound();
        }
    }
}