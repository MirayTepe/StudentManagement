using AutoMapper;
using FluentAssertions;
using WebApi.Application.CourseOperations.Commands.DeleteCourse;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.CourseOperations.Commands.Delete
{
    public class DeleteCourseCommandValidatorTests: IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(-999)]
        [InlineData(0)]
        [InlineData(-1)]
        //[InlineData(1)]
        public void WhenLowerThanAndEqualToZeroIdIsGiven_Validator_ShouldBeReturnError(int courseId)
        {
            //Arrange
            DeleteCourseCommand command=new DeleteCourseCommand(null);
            command.CourseId=courseId;

            //Act
            DeleteCourseCommandValidator validator=new DeleteCourseCommandValidator();
            var result=validator.Validate(command);

            //Assert
            result.Errors.Count.Should().BeGreaterThan(0);

        } 
        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturn()
        {
           //Arrange
            DeleteCourseCommand command=new DeleteCourseCommand(null);
            command.CourseId=1;

            //Act
            DeleteCourseCommandValidator validator=new DeleteCourseCommandValidator();
            var result=validator.Validate(command);

            //Assert
            result.Errors.Count.Should().Be(0);


        }

    }
}