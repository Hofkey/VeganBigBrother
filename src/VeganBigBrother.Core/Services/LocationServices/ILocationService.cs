using VeganBigBrother.Core.Entities;

namespace VeganBigBrother.Core.Services.LocationServices
{
    public interface ILocationService
    {
        /// <summary>
        /// Get location by its ID.
        /// </summary>
        /// <param name="id">ID of location</param>
        /// <returns>Location.</returns>
        Location GetLocation(int id);

        /// <summary>
        /// Get list of locations.
        /// </summary>
        /// <returns>List of locations.</returns>
        List<Location> GetLocations();

        /// <summary>
        /// Add a location.
        /// </summary>
        /// <param name="location">Location to add</param>
        /// <returns>Added location ID.</returns>
        Task<int> AddLocation(Location location);

        /// <summary>
        /// Delete a location.
        /// </summary>
        /// <param name="id">ID of location</param>
        Task DeleteLocation(int id);

        /// <summary>
        /// Update a location.
        /// </summary>
        /// <param name="location">Location to update</param>
        Task UpdateLocation(Location location);
    }
}