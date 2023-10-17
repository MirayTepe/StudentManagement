using AutoMapper;
using FluentAssertions;
using WebApi.Application.StudentOperations.Commands.UpdateStudent;
using WebApi.Application.TeacherOperations.Commands.UpdateTeacher;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.TeacherOperations.Commands.Update
{
    public class UpdateTeacherCommandValidatorTests: IClassFixture<CommonTestFixture>
    {
       [Theory]
        [InlineData(0,"", "", "", "", "", "")]

        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnError(int teacherId,string firstName, string lastName,string email,string identityNumber,string phoneNumber,string subject)
        {
            // Arrange
            UpdateTeacherCommand command = new UpdateTeacherCommand(null,null);
            command.TeacherId= teacherId;
            command.Model = new UpdateTeacherViewModel()
            {
                FirstName = firstName,
                LastName = lastName,
                IdentityNumber=identityNumber,
                Email=email,
                PhoneNumber=phoneNumber,
                Subject=subject
            };

            // Act
            UpdateTeacherCommandValidator validator = new UpdateTeacherCommandValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            // Arrange
            UpdateTeacherCommand command = new UpdateTeacherCommand(null,null);
            command.TeacherId = 1;
            command.Model = new UpdateTeacherViewModel()
            {
                FirstName = "testFirstName",
                LastName = "testLastName",
                IdentityNumber="10218736891",
                Email = "test@gmail.com",
                PhoneNumber="0000000000000",
                Subject="Tessst"
            };

            // Act
            UpdateTeacherCommandValidator validator = new UpdateTeacherCommandValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count.Should().Be(0);
        }
   

    }
}