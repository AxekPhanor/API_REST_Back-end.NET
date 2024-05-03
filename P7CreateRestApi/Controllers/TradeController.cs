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
        public TradeController(ITradeService tradeService)
        {
            _tradeService = tradeService;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult Home()
        {
            return Ok(_tradeService.List());
        }

        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var trade = _tradeService.Get(id);
            if (trade is not null)
            {
                return Ok(trade);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddTrade([FromBody] TradeInputModel inputModel)
        {
            _tradeService.Create(inputModel);
            return Ok(inputModel);
        }

        [HttpGet]
        [Route("validate")]
        public IActionResult Validate([FromBody]Trade trade)
        {
            // TODO: check data valid and save to db, after saving return Trade list
            return Ok();
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
        public IActionResult UpdateTrade(int id, [FromBody] TradeInputModel inputModel)
        {
            var trade = _tradeService.Update(id, inputModel);
            if (trade is not null)
            {
                return Ok(_tradeService.List());
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteTrade(int id)
        {
            var trade = _tradeService.Delete(id);
            if (trade is not null)
            {
                return Ok(_tradeService.List());
            }
            return NotFound();
        }
    }
}