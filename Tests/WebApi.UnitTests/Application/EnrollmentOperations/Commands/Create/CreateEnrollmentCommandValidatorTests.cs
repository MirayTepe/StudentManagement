using FluentAssertions;
using WebApi.Application.CourseOperations.Commands.CreateCourse;
using WebApi.Application.EnrollmentOperations.Commands.CreateEnrollment;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.EnrollmentOperations.Commands.Create
{
    public class CreateEnrolltmenCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0,0)]
        [InlineData(0,1)] 
        [InlineData(1,0)] 
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErorrs(int studentId,int courseId)
        {
            //arrange
            CreateEnrollmentCommand command = new CreateEnrollmentCommand(null,null);
            command.Model = new CreateEnrollmentViewModel()
            {
                StudentId = studentId,
                CourseId = courseId
            };

            //act
            CreateEnrollmentCommandValidator validator = new CreateEnrollmentCommandValidator();
            var results = validator.Validate(command);

            //assert
            results.Errors.Count.Should().BeGreaterThan(0);
        }

        

        
    }
}