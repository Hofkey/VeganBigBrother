using VeganBigBrother.Core.Entities;

namespace VeganBigBrother.Core.Services.SensorServices
{
    public interface ISensorService
    {
        /// <summary>
        /// Add a new sensor.
        /// </summary>
        /// <param name="sensor">Sensor to add</param>
        Task AddSensor(Sensor sensor);

        /// <summary>
        /// Get all readings for a sensor.
        /// </summary>
        /// <param name="sensorId">ID of sensor</param>
        /// <returns>List of readings for every sensor part.</returns>
        List<SensorPartReading> GetAllReadingsForSensor(int sensorId);

        /// <summary>
        /// Get readings for a sensor within a date range.
        /// </summary>
        /// <param name="sensorId">ID of sensor</param>
        /// <param name="start">Start date</param>
        /// <param name="end">End date</param>
        /// <returns>List of readings for every sensor part within specified range.</returns>
        List<SensorPartReading> GetReadingsForSensorInDateRange(int sensorId, DateTime start, DateTime end);

        /// <summary>
        /// Get a sensor by its ID.
        /// </summary>
        /// <param name="sensorId">Sensor ID</param>
        /// <returns>A sensor.</returns>
        Sensor GetSensor(int sensorId);

        /// <summary>
        /// Get a list of all the sensors.
        /// </summary>
        /// <returns>List of all the sensors.</returns>
        List<Sensor> GetSensors();

        /// <summary>
        /// Get list of sensors for a location.
        /// </summary>
        /// <param name="locationId">Location ID</param>
        /// <returns>List of sensors for a location.</returns>
        List<Sensor> GetSensorsByLocation(int locationId);

        /// <summary>
        /// Remove a sensor.
        /// </summary>
        /// <param name="sensorId">Sensor ID</param>
        Task RemoveSensor(int sensorId);

        /// <summary>
        /// Update a sensor.
        /// </summary>
        /// <param name="sensor">Sensor to update</param>
        Task UpdateSensor(Sensor sensor);
    }
}