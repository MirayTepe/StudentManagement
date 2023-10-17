using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.TeacherOperations.Queries.GetTeacherDetail;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.TeacherOperations.Queries.GetById
{
    public class GetTeacherDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(-999)]
        [InlineData(0)]
        [InlineData(-1)]
        //[InlineData(1)]
        public void WhenLowerThanAndEqualToZeroIdIsGiven_Validator_ShouldBeReturnError(int teacherId)
        {
            // Arrange
            GetTeacherDetailQuery query = new GetTeacherDetailQuery(null, null);
            query.TeacherId= teacherId;

            // Act
            GetTeacherDetailQueryValidator validator = new GetTeacherDetailQueryValidator();
            var result = validator.Validate(query);


            // Assert
            result.Errors.Count.Should().NotBe(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            // Arrange
            GetTeacherDetailQuery query = new GetTeacherDetailQuery(null, null);
            query.TeacherId = 2;

            // Act
            GetTeacherDetailQueryValidator validator = new GetTeacherDetailQueryValidator();
            var result = validator.Validate(query);

            // Assert
            result.Errors.Count.Should().Be(0);
        }
    }
}