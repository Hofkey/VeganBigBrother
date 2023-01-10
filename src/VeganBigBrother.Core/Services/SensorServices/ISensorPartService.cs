using VeganBigBrother.Core.Entities;

namespace VeganBigBrother.Core.Services.SensorServices
{
    public interface ISensorPartService
    {
        /// <summary>
        /// Get sensor part by ID.
        /// </summary>
        /// <param name="id">ID of sensor part</param>
        /// <returns>Sensor part.</returns>
        SensorPart GetSensorPart(int id);

        /// <summary>
        /// Get all sensor parts.
        /// </summary>
        /// <returns>List of all the sensor parts.</returns>
        List<SensorPart> GetSensorParts();

        /// <summary>
        /// Get sensor part types.
        /// </summary>
        /// <returns>List of sensor part types.</returns>
        Dictionary<string, int> GetSensorPartTypes();

        /// <summary>
        /// Create a sensor part.
        /// </summary>
        /// <param name="sensorPart">Sensor part to create</param>
        /// <returns>ID of created sensor part.</returns>
        Task<int> AddSensorPart(SensorPart sensorPart);

        /// <summary>
        /// Delete a sensor part.
        /// </summary>
        /// <param name="id">ID of sensor part</param>
        Task DeleteSensorPart(int id);

        /// <summary>
        /// Update a sensor part.
        /// </summary>
        /// <param name="sensorPart">Sensor part to update</param>
        Task UpdateSensorPart(SensorPart sensorPart);
    }
}