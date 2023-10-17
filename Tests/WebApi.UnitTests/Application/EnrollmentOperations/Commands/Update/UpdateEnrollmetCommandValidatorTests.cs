using FluentAssertions;
using WebApi.Application.CourseOperations.Commands.CreateCourse;
using WebApi.Application.EnrollmentOperations.Commands.CreateEnrollment;
using WebApi.Application.EnrollmentOperations.Commands.UpdateEnrollment;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.EnrollmentOperations.Commands.Update
{
    public class UpdateEnrolltmenCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
     
        [Theory]
        [InlineData(0,0)]
        [InlineData(1,0)]
        [InlineData(0,1)]
        [InlineData(null,1)]
        [InlineData(1,null)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErorrs(int courseId, int studentId)
        {
            //arrange
            UpdateEnrollmentCommand command = new UpdateEnrollmentCommand(null,null);
            command.Model = new UpdateEnrollmentViewModel()
            {
                CourseId = courseId,
                StudentId = studentId
            };

            //act
            UpdateEnrollmentCommandValidator validator = new UpdateEnrollmentCommandValidator();
            var results = validator.Validate(command);

            //assert
            results.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData(1,1)]                                
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErorrs(int courseId, int studentId)
        {
            //arrange
            UpdateEnrollmentCommand command = new UpdateEnrollmentCommand(null,null);
            command.Model = new UpdateEnrollmentViewModel()
            {
                CourseId = courseId,
                StudentId = studentId
            };

            //act
            UpdateEnrollmentCommandValidator validator = new UpdateEnrollmentCommandValidator();
            var results = validator.Validate(command);

            //assert
            results.Errors.Count.Should().BeLessThanOrEqualTo(0);
        }

        
    }
}