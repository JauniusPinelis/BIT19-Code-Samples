using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SquaresWebApi.Validators
{
    public abstract class ValidatorBase<T> : AbstractValidator<T>
    {
        public void ValidateModel(T obj)
        {
            ValidationResult validation = Validate(obj);

            if (validation.Errors.Select(e => e.ErrorMessage).Any())
            {
                throw new ArgumentException(string.Join("; ", validation.Errors.Select(e => e.ErrorMessage)));
            }
        }

        public void ValidateRangeOfModels(List<T> objs)
        {
            foreach(var obj in objs)
            {
                ValidateModel(obj);
            }
        }
    }
}
