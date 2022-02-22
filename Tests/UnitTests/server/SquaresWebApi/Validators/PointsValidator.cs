using FluentValidation;
using SquaresWebApi.Dtos.PointDtos;
using System.Collections.Generic;

namespace SquaresWebApi.Validators
{
    public class PointsValidator : ValidatorBase<PointCreateDto>
    {
        public PointsValidator()
        {
            RuleFor(p => p.X).InclusiveBetween(-5000, 5000);

            RuleFor(p => p.X).InclusiveBetween(-5000, 5000);
        }

        public void RunCreateValidation(List<PointCreateDto> pointsDto)
        {
            ValidateRangeOfModels(pointsDto);
        }
    }
}
