using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VeganBigBrother.API.Models;
using VeganBigBrother.Core.Entities;
using VeganBigBrother.Core.Services.LocationServices;

namespace VeganBigBrother.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILocationService locationService;

        public LocationController(IMapper mapper,
            ILocationService locationService)
        {
            this.mapper = mapper;
            this.locationService = locationService;
        }

        // GET: api/<LocationController>
        [HttpGet]
        public IActionResult Get()
        {
            var locations = locationService.GetLocations();
            var mapped = mapper.Map<List<LocationPOCO>>(locations);
            return Ok(mapped);
        }

        // GET api/<LocationController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var location = locationService.GetLocation(id);

            if(location == null)
            {
                return NotFound();
            }

            var mapped = mapper.Map<LocationPOCO>(location);
            return Ok(mapped);
        }

        // POST api/<LocationController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LocationPOCO location)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mapped = mapper.Map<Location>(location);
            var result = await locationService.AddLocation(mapped);

            return Ok(result);
        }

        // PUT api/<LocationController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] LocationPOCO location)
        {
            if (!ModelState.IsValid || id != location.Id)
            {
                return BadRequest(ModelState);
            }

            if(locationService.GetLocation(id) == null)
            {
                return NotFound();
            }

            var mapped = mapper.Map<Location>(location);

            await locationService.UpdateLocation(mapped);

            return Ok();
        }

        // DELETE api/<LocationController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (locationService.GetLocation(id) == null)
            {
                return NotFound();
            }

            await locationService.DeleteLocation(id);

            return Ok();
        }
    }
}
