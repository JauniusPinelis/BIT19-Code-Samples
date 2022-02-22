using SquaresWebApi.Dtos.PointDtos;
using System.Collections.Generic;

namespace SquaresWebApi.Dtos.PointsCollectionDtos
{
    public class PointsCollectionUpdateDto
    {
        public List<PointUpdateDto> Points { get; set; }
    }
}
