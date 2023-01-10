using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VeganBigBrother.API.Models;
using VeganBigBrother.Core.Aggregates;
using VeganBigBrother.Core.Exceptions;
using VeganBigBrother.Core.Services.SensorServices;

namespace VeganBigBrother.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ISensorService sensorService;

        public SensorController(IMapper mapper, ISensorService sensorService)
        {
            this.mapper = mapper;
            this.sensorService = sensorService;
        }

        // GET: api/<SensorController>
        [HttpGet]
        public IActionResult Get()
        {
            var sensors = sensorService.GetSensors();
            var mapped = mapper.Map<List<SensorPOCO>>(sensors);

            return Ok(mapped);
        }

        // GET api/<SensorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var sensor = sensorService.GetSensor(id);
                return Ok(mapper.Map<SensorPOCO>(sensor));
            }
            catch (EntityDoesNotExistException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET api/<SensorController>/5
        [HttpGet("location/{id}")]
        public IActionResult GetByLocation(int id)
        {
            var sensors = sensorService.GetSensorsByLocation(id);
            var mapped = mapper.Map<List<SensorPOCO>>(sensors);

            return Ok(mapped);
        }

        // POST api/<SensorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SensorPOCO sensor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sensorAggregate = mapper.Map<SensorAggregate>(sensor);

            var result = await sensorService.AddSensor(sensorAggregate);

            return Ok(result);
        }
    }
}
