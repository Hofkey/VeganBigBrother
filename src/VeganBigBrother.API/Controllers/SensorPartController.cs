using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VeganBigBrother.API.Models;
using VeganBigBrother.Core.Entities;
using VeganBigBrother.Core.Services.SensorServices;

namespace VeganBigBrother.API.Controllers
{
    [Route("api/sensor/part")]
    [ApiController]
    public class SensorPartController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ISensorPartService sensorPartService;

        public SensorPartController(IMapper mapper, 
            ISensorPartService sensorPartService)
        {
            this.mapper = mapper;
            this.sensorPartService = sensorPartService;
        }

        // GET: api/sensor/part
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(sensorPartService.GetSensorParts());
        }

        // GET api/sensor/part/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var sensorPart = sensorPartService.GetSensorPart(id);

            if(sensorPart == null)
            {
                return NotFound();
            }

            return Ok(sensorPart);
        }

        [HttpGet("types")]
        public IActionResult GetSensorPartTypes() 
        { 
            var sensorPartTypes = sensorPartService.GetSensorPartTypes();

            return Ok(sensorPartTypes);
        }

        // POST api/sensor/part
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SensorPartPOCO sensorPart)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mapped = mapper.Map<SensorPart>(sensorPart);
            var result = await sensorPartService.AddSensorPart(mapped);

            return Ok(result);
        }

        // PUT api/sensor/part/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SensorPartPOCO sensorPart)
        {
            if (!ModelState.IsValid || id != sensorPart.Id)
            {
                return BadRequest(ModelState);
            }

            if (sensorPartService.GetSensorPart(id) == null)
            {
                return NotFound();
            }

            var mapped = mapper.Map<SensorPart>(sensorPart);

            await sensorPartService.UpdateSensorPart(mapped);

            return Ok();
        }

        // DELETE api/sensor/part/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (sensorPartService.GetSensorPart(id) == null)
            {
                return NotFound();
            }

            await sensorPartService.DeleteSensorPart(id);

            return Ok();
        }
    }
}
