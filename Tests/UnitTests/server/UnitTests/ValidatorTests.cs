using SquaresWebApi.Dtos.PointDtos;
using SquaresWebApi.Validators;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class ValidatorTests
    {
        [Fact]
        public void RunCreateValidation_GivenOverLimitX_ArgumentExceptionGetsThrown()
        {
            //aaa
            //Arrange
            var validator = new PointsValidator();

            var points = new List<PointCreateDto>
            {
                new PointCreateDto
                {
                    X = 99999,
                    Y = 0
                },
                 new PointCreateDto
                {
                    X = 1,
                    Y = 1
                }
            };

            // Action assert
            Assert.Throws<ArgumentException>(() => validator.RunCreateValidation(points));
        }

        [Fact]
        public void RunCreateValidation_GivenCorrectData_NoExceptionsGetsThrown()
        {
            //aaa
            //Arrange
            var validator = new PointsValidator();

            var points = new List<PointCreateDto>
            {
                new PointCreateDto
                {
                    X = 0,
                    Y = 0
                },
                 new PointCreateDto
                {
                    X = 1,
                    Y = 1
                }
            };

            // Action assert
            validator.RunCreateValidation(points);
        }
    }
}