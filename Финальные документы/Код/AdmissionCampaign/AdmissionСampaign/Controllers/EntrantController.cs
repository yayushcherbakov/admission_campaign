using AdmissionCampaign.ViewModels.Entrants;
using AdmissionСampaign.DataAccess.Entities;
using AdmissionСampaign.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionСampaign.Controllers
{
    [ApiController]
    [Route("Entrant")]
    public class EntrantController : ControllerBase
    {
        private readonly EntrantService _entrantService;

        public EntrantController(EntrantService entrantService)
        {
            _entrantService = entrantService;
        }

        [HttpPut("AddEntrant")]
        [ProducesResponseType(typeof(long), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult AddEntrant([FromBody] AddEntrantViewModel model)
        {
            var id = _entrantService.AddEntrant(model);
            return Ok(id);
        }

        [HttpPost("UpdateEntrant")]
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult UpdateEntrant([FromBody] UpdateEntrantViewModel model)
        {
            _entrantService.UpdateEntrant(model);
            return Ok();
        }

        [HttpDelete("RemoveEntrant/{id}")]
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult RemoveEntrant([FromRoute] long id)
        {
            _entrantService.RemoveEntrant(id);
            return Ok();
        }

        [HttpDelete("RemoveAllEntrants")]
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult RemoveAllEntrants()
        {
            _entrantService.RemoveAllEntrants();
            return Ok();
        }

        [HttpGet("GetByEntrantId/{id}")]
        [ProducesResponseType(typeof(EntrantView), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult GetByEntrantId([FromRoute] long id)
        {
            var entrant = _entrantService.FindEntrantById(id);
            return Ok(entrant);
        }

        [HttpGet("GetAllEntrants")]
        [ProducesResponseType(typeof(FiltredEntrantsView), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult GetAllEntrants([FromQuery] PaginationViewModel model)
        {
            var entrants = _entrantService.GetAllEntrants(model);
            return Ok(entrants);
        }

        [HttpGet("GetEntrantsByEntryYear")]
        [ProducesResponseType(typeof(FiltredEntrantsView), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult GetEntrantsByEntryYear([FromQuery] GetEntrantsByEntryYearViewModel model)
        {
            var entrants = _entrantService.GetEntrantsByEntryYear(model);
            return Ok(entrants);
        }

        [HttpGet("FilterEntrants")]
        [ProducesResponseType(typeof(FiltredEntrantsView), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult FilterEntrants([FromQuery] FilterEntrantsViewModel model)
        {
            var entrants = _entrantService.FilterEntrants(model);
            return Ok(entrants);
        }

        [HttpGet("GetStaticticByRegions")]
        [ProducesResponseType(typeof(GetStaticticByRegionsView), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult GetStaticticByRegions([FromQuery] GetStaticticByRegionsViewModel model)
        {
            var entrants = _entrantService.GetStaticticByRegions(model);
            return Ok(entrants);
        }

        [HttpPost("UploadDocument")]
        public IActionResult UploadDocument([FromQuery] int entryYear, [FromQuery] string educationProgram, [FromForm] IFormFile file)
        {
            if (string.IsNullOrWhiteSpace(educationProgram))
            {
                return BadRequest("EducationProgram is required");
            }
            if (entryYear <= 0)
            {
                return BadRequest("EntryYear is required and positive");
            }
            if (file.Length <= 0)
            {
                return BadRequest("File is empty");
            }
            using var fileStream = file.OpenReadStream();

            _entrantService.UploadDocument(entryYear, educationProgram, fileStream);

            return Ok();
        }
    }
}
