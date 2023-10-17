using AutoMapper;
using FluentAssertions;
using WebApi.Application.CourseOperations.Commands.CreateCourse;
using WebApi.Application.CourseOperations.Commands.DeleteCourse;
using WebApi.Application.CourseOperations.Commands.UpdateCourse;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.CourseOperations.Commands.Update
{
    public class UpdateCourseCommandValidatorTests: IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(1,0, "", "","","")] 
        [InlineData(1,0, "test", "","","")] 
        [InlineData(1,0, "test", "test","","")] 
        [InlineData(0,1, "test", "","","")]
        [InlineData(0,1, "test", "test","","")]
        [InlineData(0,0, "test", "test","","")]
        [InlineData(0,1, "test", "test","test","test")]
     
      

        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnError(int courseId,int teacherId, string courseName, string courseCode, string description,string shedule)
        {
            // Arrange
            UpdateCourseCommand command = new UpdateCourseCommand(null,null);
            command.CourseId = courseId;
            command.Model = new UpdateCourseViewModel()
            {
                
                TeacherId=teacherId,
                CourseName = courseName,
                CourseCode = courseCode,
                Description = description,
                Schedule = shedule

            };

            // Act
            UpdateCourseCommandValidator validator = new UpdateCourseCommandValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            // Arrange
            UpdateCourseCommand command = new UpdateCourseCommand(null,null);
            command.CourseId = 1;
            command.Model = new UpdateCourseViewModel()
            {
                CourseName = "tesstt",
                TeacherId=2,
                CourseCode = "tesst202",
                Description = "description",
                Schedule = "Pazartesi 12:30"
            };

            // Act
            UpdateCourseCommandValidator validator = new UpdateCourseCommandValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count.Should().Be(0);
        }
   

    }
}