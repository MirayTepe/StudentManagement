using FluentAssertions;
using WebApi.Application.CourseOperations.Commands.CreateCourse;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.CourseOperations.Commands.Create
{
    public class CreateCourseCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("","",0,"","")]
        [InlineData("","test",0,"","")]
        [InlineData("test","",0,"","")]  
        [InlineData("","",1,"","")]
        [InlineData("","",0,"test","")]
        [InlineData("","",0,"","test")]   
        [InlineData("","test",1,"test","test")] 
        [InlineData("test","",1,"test","test")]  
        [InlineData("test","test",0,"test","test")]  
        [InlineData("test","test",1,"","test")] 
        [InlineData("test","test",1,"test","")] 
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErorrs(string courseName, string courseCode,int teacherId,string description,string shedule)
        {
            //arrange
            CreateCourseCommand command = new CreateCourseCommand(null,null);
            command.Model = new CreateCourseViewModel()
            {
                CourseName = courseName,
                CourseCode = courseCode,
                TeacherId=teacherId,
                Description=description,
                Schedule=shedule
            };

            //act
            CreateCourseCommandValidator validator = new CreateCourseCommandValidator();
            var results = validator.Validate(command);

            //assert
            results.Errors.Count.Should().BeGreaterThan(0);
        }

        

        
    }
}