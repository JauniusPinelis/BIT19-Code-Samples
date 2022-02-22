using SquaresWebApi.Dtos.PointDtos;
using System.Collections.Generic;

namespace SquaresWebApi.Dtos.PointsCollectionDtos
{
    public class PointsCollectionCreateDto : PointsCollectionDtoBase
    {
        public List<PointCreateDto> Points { get; set; }
    }
}
