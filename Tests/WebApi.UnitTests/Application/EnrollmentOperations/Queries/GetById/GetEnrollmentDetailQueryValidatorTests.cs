using AutoMapper;
using FluentAssertions;
using WebApi.Application.EnrollmentOperations.Commands.CreateEnrollment;
using WebApi.Application.EnrollmentOperations.Commands.UpdateEnrollment;
using WebApi.Application.EnrolmenttOperations.Queries.GetEnrollmentDetail;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.EnrollmentOperations.Queries.GetEnrollmentDetail
{
    public class GetEnrollmentDetailQueryValidatorTests: IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(-999)]
        [InlineData(0)]
        [InlineData(-1)]
        //[InlineData(1)]
        public void WhenLowerThanAndEqualToZeroIdIsGiven_Validator_ShouldBeReturnError(int enrollmentId)
        {
            // Arrange
            GetEnrollmentDetailQuery query = new GetEnrollmentDetailQuery(null, null);
            query.EnrollmentId = enrollmentId;

            // Act
            GetEnrollmentDetailQueryValidator validator = new GetEnrollmentDetailQueryValidator();
            var result = validator.Validate(query);


            // Assert
            result.Errors.Count.Should().NotBe(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            // Arrange
            GetEnrollmentDetailQuery query = new GetEnrollmentDetailQuery(null, null);
            query.EnrollmentId = 2;

            // Act
            GetEnrollmentDetailQueryValidator validator = new GetEnrollmentDetailQueryValidator();
            var result = validator.Validate(query);

            // Assert
            result.Errors.Count.Should().Be(0);
        }

    }
}