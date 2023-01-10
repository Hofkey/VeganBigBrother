using VeganBigBrother.Core.Entities;
using VeganBigBrother.Core.Interfaces;

namespace VeganBigBrother.Core.Services.SensorServices
{
    public class SensorService : ISensorService
    {
        private readonly IRepository<Sensor> sensorRepository;
        private readonly IRepository<SensorPartReading> sensorPartReadingRepository;

        public SensorService(IRepository<Sensor> sensorRepository,
            IRepository<SensorPartReading> sensorPartReadingRepository)
        {
            this.sensorRepository = sensorRepository;
            this.sensorPartReadingRepository = sensorPartReadingRepository;
        }

        public Sensor GetSensor(int sensorId)
        {
            return sensorRepository.GetById(sensorId);
        }

        public List<Sensor> GetSensors()
        {
            return sensorRepository.Get(sensor => sensor.Id > 0, null, "SensorParts").ToList();
        }

        public List<Sensor> GetSensorsByLocation(int locationId)
        {
            return sensorRepository.Get(sensor => sensor.LocationID == locationId, null, "SensorParts").ToList();
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

        public async Task AddSensor(Sensor sensor)
        {
            await sensorRepository.Create(sensor);
        }

        public async Task UpdateSensor(Sensor sensor)
        {
            await sensorRepository.Update(sensor);
        }

        public async Task RemoveSensor(int sensorId)
        {
            await sensorRepository.Delete(sensorId);
        }
    }
}
