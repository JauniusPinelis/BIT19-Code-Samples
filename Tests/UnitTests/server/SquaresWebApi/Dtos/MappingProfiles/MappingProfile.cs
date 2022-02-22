using AutoMapper;
using SquaresWebApi.Dtos.PointDtos;
using SquaresWebApi.Dtos.PointsCollectionDtos;
using SquaresWebApi.Models;

namespace SquaresWebApi.Dtos.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PointsCollection, PointsCollectionGetDto>().ReverseMap();
            CreateMap<Point, PointGetDto>().ReverseMap();

            CreateMap<PointsCollection, PointsCollectionCreateDto>().ReverseMap();
            CreateMap<Point, PointCreateDto>().ReverseMap();

            CreateMap<PointsCollection, PointsCollectionGetAllDto>();
        }
    }
}
