using AutoMapper;
using VeganBigBrother.API.Models;
using VeganBigBrother.Core.Aggregates;
using VeganBigBrother.Core.Entities;

namespace VeganBigBrother.API.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SensorAggregate, SensorPOCO>().ReverseMap();
            CreateMap<SensorPart, SensorPartPOCO>().ReverseMap();
            CreateMap<SensorPartReading, SensorPartReadingPOCO>().ReverseMap();
            CreateMap<Location, LocationPOCO>().ReverseMap();
        }
    }
}
