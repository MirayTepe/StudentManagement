using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.CourseOperations.Commands.GetCourseDetail;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.CourseOperations.Queries.GetById
{
    public class GetBookDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(-999)]
        [InlineData(0)]
        [InlineData(-1)]
        //[InlineData(1)]
        public void WhenLowerThanAndEqualToZeroIdIsGiven_Validator_ShouldBeReturnError(int courseId)
        {
            // Arrange
            GetCourseDetailQuery query = new GetCourseDetailQuery(null, null);
            query.CourseId = courseId;

            // Act
            GetCourseDetailQueryValidator validator = new GetCourseDetailQueryValidator();
            var result = validator.Validate(query);


            // Assert
            result.Errors.Count.Should().NotBe(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            // Arrange
            GetCourseDetailQuery query = new GetCourseDetailQuery(null, null);
            query.CourseId = 2;

            // Act
            GetCourseDetailQueryValidator validator = new GetCourseDetailQueryValidator();
            var result = validator.Validate(query);

            // Assert
            result.Errors.Count.Should().Be(0);
        }
    }
}