using FluentValidation;
using SquaresWebApi.Dtos.PointsCollectionDtos;

namespace SquaresWebApi.Validators
{
    public class PointsCollectionsValidator : ValidatorBase<PointsCollectionCreateDto>
    {
        public PointsCollectionsValidator()
        {
            RuleFor(s => s.Name).NotEmpty();
        }

        public void RunCreateValidation(PointsCollectionCreateDto collectionsDto)
        {
            ValidateModel(collectionsDto);
        }
    }
}
