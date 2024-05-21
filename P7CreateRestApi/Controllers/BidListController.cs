using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Services;
using Serilog;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BidListController : ControllerBase
    {
        private readonly IBidListService _bidListService;
        public BidListController(IBidListService bidListService) 
        { 
            _bidListService = bidListService;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {
            try
            {
                Log.Information("Récupération de la liste des 'BidList'");
                return Ok(_bidListService.List());
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Une erreur s'est produite lors de la récupération de la liste des 'BidList'");
                return StatusCode(500, "Une erreur interne s'est produite");
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            Log.Information("Récupération de 'BidList' avec l'id : {id}", id);
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
                Log.Error(ex, "Erreur lors de la récupération de 'BidList avec l'id : {id}'", id);
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddBidList([FromBody] BidListInputModel inputModel)
        {
            Log.Information("Ajout d'une 'BidList'");
            try
            {
                _bidListService.Create(inputModel);
                return Ok(inputModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur lors de l'ajout d'une 'BidList'");
                return StatusCode(500, "Une erreur interne s'est produite");
            }
        }

        [HttpGet]
        [Route("update/{id}")]
        public IActionResult ShowUpdateForm(int id)
        {
            Log.Information("Récupération sur la route 'update/id' de 'BidList' avec l'id : {id}", id);

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
                Log.Error(ex, "Erreur lors de la récupération de 'BidList' avec l'id : {id}", id);
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult UpdateById([FromRoute] int id, [FromBody] BidListInputModel inputModel)
        {
            Log.Information("Mise à jour de 'BidList' avec l'id : {id}", id);
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
                Log.Error(ex, "Erreur lors de la mise à jour de 'BidList avec l'id : {id}'", id);
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteById([FromRoute] int id)
        {
            Log.Information("Suppression de 'BidList' avec l'id : {id}", id);
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
                Log.Error(ex, "Erreur lors de la suppression de 'BidList avec l'id : {id}'", id);
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }
    }
}