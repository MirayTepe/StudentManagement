using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.CourseOperations.Commands.GetCourseDetail;
using WebApi.Application.StudentOperations.Queries.GetStudentDetail;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.StudentOpreations.Queries.GetById
{
    public class GetStudentDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(-999)]
        [InlineData(0)]
        [InlineData(-1)]
        //[InlineData(1)]
        public void WhenLowerThanAndEqualToZeroIdIsGiven_Validator_ShouldBeReturnError(int studentId)
        {
            // Arrange
            GetStudentDetailQuery query = new GetStudentDetailQuery(null, null);
            query.StudentId= studentId;

            // Act
            GetStudentDetailQueryValidator validator = new GetStudentDetailQueryValidator();
            var result = validator.Validate(query);


            // Assert
            result.Errors.Count.Should().NotBe(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            // Arrange
            GetStudentDetailQuery query = new GetStudentDetailQuery(null, null);
            query.StudentId = 2;

            // Act
            GetStudentDetailQueryValidator validator = new GetStudentDetailQueryValidator();
            var result = validator.Validate(query);

            // Assert
            result.Errors.Count.Should().Be(0);
        }
    }
}