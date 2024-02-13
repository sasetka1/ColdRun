using ColdRun.API.Models;
using ColdRun.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OperationResult;

namespace ColdRun.API.Controllers
{
    /// <summary>
    /// API endpoints for retrieving Trucks
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TruckController : ControllerBase
    {

        private readonly ILogger<TruckController> _logger;
        private readonly ITruckService _truckService;

        public TruckController(ILogger<TruckController> logger, ITruckService truckService)
        {
            _logger = logger;
            _truckService = truckService;
        }
        [HttpGet]
        [Route("Get/{code}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Truck), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        //  [MapToApiVersion(Constants.Version)]
        // [SwaggerResponseExample(200, typeof(TruckExample))]


        public async Task<IActionResult> Get(string code)
        {
            var result = await _truckService.Get(code);

            if (result.IsSuccess)
            {
                return result.Value == null
                    ? NotFound("Not found")
                    : Ok(result.Value);
            }

            return BadRequest(result.Error);
        }

        [HttpGet]
        [Route("GetAll")]       
        [Produces("application/json")]
        [ProducesResponseType(typeof(PagedList<Truck>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        //  [MapToApiVersion(Constants.Version)]
        //  [SwaggerResponseExample(200, typeof(TrucksExample))]
        public async Task<ActionResult<IEnumerable<Truck>>> GetAll([ FromQuery] string? name = null, [FromQuery] string? status = null, [FromQuery] string? sortBy = null, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = int.MaxValue)
        {
            if (pageNumber <= 0)
                return BadRequest("pageNumber must be a number larger than 0");

            if (pageSize <= 0)
                return BadRequest("pageSize must be a number larger than 0");

            var result = await _truckService.GetAll(name, status, sortBy,pageNumber, pageSize);

          
             return result.HasValue == false
                    ? NotFound("Not found")
                    : (result.Value.IsSuccess ? Ok(result.Value.Value) : BadRequest(result.Value.Error));
        }


        [HttpPost]
        [ProducesResponseType(typeof(Status<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] Truck truck)
        {
            var result = await _truckService.Create(truck);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result.Error);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Status<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] Truck truck)
        {
            var result = await _truckService.Update(truck);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result.Error);
        }

        [HttpDelete("{code}")]
        [ProducesResponseType(typeof(Status<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(string code)
        {
            var result = await _truckService.Delete(code);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result.Error);
        }
    }
}
