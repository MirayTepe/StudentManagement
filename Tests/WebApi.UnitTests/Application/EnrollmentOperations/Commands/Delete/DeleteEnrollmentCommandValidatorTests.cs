using AutoMapper;
using FluentAssertions;
using WebApi.Application.CourseOperations.Commands.DeleteCourse;
using WebApi.Application.EnrollmentOperations.Commands.DeleteEnrollment;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.EnrollmentOperations.Commands.Delete
{
    public class DeleteEnrollmentCommandValidatorTests: IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(-999)]
        [InlineData(0)]
        [InlineData(-1)]
        //[InlineData(1)]
        public void WhenLowerThanAndEqualToZeroIdIsGiven_Validator_ShouldBeReturnError(int enrollmentId)
        {
            //Arrange
            DeleteEnrollmentCommand command=new DeleteEnrollmentCommand(null);
            command.EnrollmentId=enrollmentId;

            //Act
            DeleteEnrollmentCommandValidator validator=new DeleteEnrollmentCommandValidator();
            var result=validator.Validate(command);

            //Assert
            result.Errors.Count.Should().BeGreaterThan(0);

        } 
        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturn()
        {
           //Arrange
            DeleteEnrollmentCommand command=new DeleteEnrollmentCommand(null);
            command.EnrollmentId=1;

            //Act
            DeleteEnrollmentCommandValidator validator=new DeleteEnrollmentCommandValidator();
            var result=validator.Validate(command);

            //Assert
            result.Errors.Count.Should().Be(0);


        }

    }
}