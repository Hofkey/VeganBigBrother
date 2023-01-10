using VeganBigBrother.Core.Entities;
using VeganBigBrother.Core.Interfaces;

namespace VeganBigBrother.Core.Services.LocationServices
{
    public class LocationService : ILocationService
    {
        private readonly IRepository<Location> locationRepository;

        public LocationService(IRepository<Location> locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        public Location GetLocation(int id)
        {
            return locationRepository.GetById(id);
        }

        public List<Location> GetLocations()
        {
            return locationRepository.Get(location => location.Id > 0).ToList();
        }

        public async Task<int> AddLocation(Location location)
        {
            return await locationRepository.Create(location);
        }

        public async Task UpdateLocation(Location location)
        {
            await locationRepository.Update(location);
        }

        public async Task DeleteLocation(int id)
        {
            await locationRepository.Delete(id);
        }
    }
}
