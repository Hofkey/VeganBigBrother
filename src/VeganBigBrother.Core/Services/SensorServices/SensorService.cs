using VeganBigBrother.Core.Aggregates;
using VeganBigBrother.Core.Entities;
using VeganBigBrother.Core.Exceptions;
using VeganBigBrother.Core.Interfaces;

namespace VeganBigBrother.Core.Services.SensorServices
{
    public class SensorService : ISensorService
    {
        private readonly IRepository<Sensor> sensorRepository;
        private readonly IRepository<SensorSensorPart> sensorSensorPartRepository;
        private readonly IRepository<SensorPartReading> sensorPartReadingRepository;

        public SensorService(IRepository<Sensor> sensorRepository,
            IRepository<SensorSensorPart> sensorSensorPartRepository,
            IRepository<SensorPartReading> sensorPartReadingRepository)
        {
            this.sensorRepository = sensorRepository;
            this.sensorSensorPartRepository = sensorSensorPartRepository;
            this.sensorPartReadingRepository = sensorPartReadingRepository;
        }

        public SensorAggregate GetSensor(int sensorId)
        {
            var sensor = sensorRepository.Get(sensor => sensor.Id == sensorId, null, "Location").SingleOrDefault();

            if(sensor == null)
            {
                throw new EntityDoesNotExistException(typeof(Sensor), sensorId);
            }

            return CreateSensorAggregate(sensor);
        }

        public List<SensorAggregate> GetSensors()
        {
            var sensorAggregates = new List<SensorAggregate>();
            var sensors = sensorRepository.Get(sensor => sensor.Id > 0, null, "Location").ToList();

            foreach(var sensor in sensors)
            {
                sensorAggregates.Add(CreateSensorAggregate(sensor));
            }

            return sensorAggregates;
        }

        public List<SensorAggregate> GetSensorsByLocation(int locationId)
        {
            var sensorAggregates = new List<SensorAggregate>();
            var sensors = sensorRepository.Get(sensor => sensor.LocationID == locationId, null, "Location").ToList();

            foreach (var sensor in sensors)
            {
                sensorAggregates.Add(CreateSensorAggregate(sensor));
            }

            return sensorAggregates;
        }

        public List<SensorPartReading> GetAllReadingsForSensor(int sensorId)
        {
            return sensorPartReadingRepository.Get(sensorPartReading => sensorPartReading.SensorID == sensorId).ToList();
        }

        public List<SensorPartReading> GetReadingsForSensorInDateRange(int sensorId, DateTime start, DateTime end)
        {
            return sensorPartReadingRepository.Get(sensorPartReading => sensorPartReading.SensorID == sensorId
                && sensorPartReading.Time >= start
                && sensorPartReading.Time <= end).ToList();
        }

        public async Task<int> AddSensor(SensorAggregate sensorAggregate)
        {
#pragma warning disable CS8602 // Location is already being checked by DataAnnotations.
            var sensor = new Sensor
            {
                Name = sensorAggregate.Name,
                LocationID = sensorAggregate.Location.Id,
                Type = sensorAggregate.Type,
            };
#pragma warning restore CS8602 // Location is already being checked by DataAnnotations.

            var sensorId = await sensorRepository.Create(sensor);

            foreach (var sensorPart in sensorAggregate.SensorParts)
            {
                var sensorSensorPart = new SensorSensorPart
                {
                    SensorId = sensorId,
                    SensorPartId = sensorPart.Id,
                };

                await sensorSensorPartRepository.Create(sensorSensorPart);
            }

            return sensorId;
        }

        public async Task UpdateSensor(Sensor sensor)
        {
            await sensorRepository.Update(sensor);
        }

        public async Task RemoveSensor(int sensorId)
        {
            await sensorRepository.Delete(sensorId);
        }

        /// <summary>
        /// Create a sensor aggregate for a sensor.
        /// </summary>
        /// <param name="sensor">Sonser to convert</param>
        /// <returns>A sensor aggregate.</returns>
        private SensorAggregate CreateSensorAggregate(Sensor sensor)
        {
            var sensorAggregate = new SensorAggregate(sensor);

            foreach (var sensorPart in GetSensorParts(sensor.Id))
            {
                sensorAggregate.SensorParts.Add(sensorPart);
            }

            return sensorAggregate;
        }

        /// <summary>
        /// Get a list of sensor parts for a sensor.
        /// </summary>
        /// <param name="sensorId">Sensor ID</param>
        /// <returns>List of sensor parts for a sensor.</returns>
        private List<SensorPart> GetSensorParts(int sensorId)
        {
            return sensorSensorPartRepository.Get(sensorSensorPart => sensorSensorPart.SensorId == sensorId, null, "SensorPart")
                .Select(result => result.SensorPart)
                .ToList();
        }
    }
}
