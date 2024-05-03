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

        public CurveController(ICurvePointService curvePointService)
        {
            _curvePointService = curvePointService;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult Home()
        {
            return Ok(_curvePointService.List());
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var curvePoint = _curvePointService.Get(id);
            if(curvePoint is not null)
            {
                return Ok(curvePoint);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddCurvePoint([FromBody] CurvePointInputModel inputModel)
        {
            _curvePointService.Create(inputModel);
            return Ok(inputModel);
        }

        [HttpPost]
        [Route("validate")]
        public IActionResult Validate([FromBody] CurvePointInputModel inputModel)
        {
            // TODO: check data valid and save to db, after saving return bid list
            return Ok();
        }

        [HttpGet]
        [Route("update/{id}")]
        public IActionResult ShowUpdateForm(int id)
        {
            // TODO: get CurvePoint by Id and to model then show to the form
            return Ok();
        }

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult UpdateById([FromRoute] int id, [FromBody] CurvePointInputModel inputModel)
        {
            var curvePoint = _curvePointService.Update(id, inputModel);
            if (curvePoint is not null)
            {
                return Ok(_curvePointService.List());
            }
            return NotFound();
            
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteById(int id)
        {
            var curvePoint = _curvePointService.Delete(id);
            if (curvePoint is not null)
            {
                return Ok(_curvePointService.List());
            }
            return NotFound();
        }
    }
}