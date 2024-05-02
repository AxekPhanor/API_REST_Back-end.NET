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

        [HttpPost]
        [Route("add")]
        public IActionResult AddCurvePoint([FromBody] CurvePointInputModel curvePoint)
        {
            _curvePointService.Create(curvePoint);
            return Ok(curvePoint);
        }

        [HttpPost]
        [Route("validate")]
        public IActionResult Validate([FromBody] CurvePointInputModel curvePoint)
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
        public IActionResult UpdateCurvePoint(int id, [FromBody] CurvePointInputModel curvePoint)
        {
            _curvePointService.Update(id, curvePoint);
            return Ok(_curvePointService.List());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteById(int id)
        {
            _curvePointService.Delete(id);
            return Ok(_curvePointService.List());
        }
    }
}