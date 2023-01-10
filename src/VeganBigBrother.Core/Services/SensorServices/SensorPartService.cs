using VeganBigBrother.Core.Entities;
using VeganBigBrother.Core.Enums;
using VeganBigBrother.Core.Interfaces;

namespace VeganBigBrother.Core.Services.SensorServices
{
    public class SensorPartService : ISensorPartService
    {
        private readonly IRepository<SensorPart> sensorPartRepository;

        public SensorPartService(IRepository<SensorPart> sensorPartRepository)
        {
            this.sensorPartRepository = sensorPartRepository;
        }

        public SensorPart GetSensorPart(int id)
        {
            return sensorPartRepository.GetById(id);
        }

        public List<SensorPart> GetSensorParts()
        {
            return sensorPartRepository.Get(sensorPart => sensorPart.Id > 0).ToList();
        }

        public Dictionary<string, int> GetSensorPartTypes()
        {
            return Enum.GetValues(typeof(SensorPartType))
               .Cast<SensorPartType>()
               .ToDictionary(t => t.ToString(), t => (int)t);
        }

        public async Task<int> AddSensorPart(SensorPart sensorPart)
        {
            return await sensorPartRepository.Create(sensorPart);
        }

        public async Task UpdateSensorPart(SensorPart sensorPart)
        {
            await sensorPartRepository.Update(sensorPart);
        }

        public async Task DeleteSensorPart(int id)
        {
            await sensorPartRepository.Delete(id);
        }
    }
}
