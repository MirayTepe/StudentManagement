using AutoMapper;
using FluentAssertions;
using WebApi.Application.StudentOperations.Commands.UpdateStudent;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.StudentOpreations.Commands.Update
{
    public class UpdateStudentCommandValidatorTests: IClassFixture<CommonTestFixture>
    {
       [Theory]
       [InlineData(0,"", "", "2002-09-12", "", "", "", "", "", "")]

        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnError(int studentId,string firstName, string lastName,string dateOfBirth, string email,string identityNumber,string gender,string courseClass,string schoolNumber,string phoneNumber)
        {
            // Arrange
            UpdateStudentCommand command = new UpdateStudentCommand(null,null);
            command.StudentId = studentId;
            command.Model = new UpdateStudentViewModel()
            {
                FirstName = firstName,
                LastName = lastName,
                IdentityNumber=identityNumber,
                Class=courseClass,
                DateOfBirth=DateTime.Parse(dateOfBirth),
                Gender=gender,
                Email=email,
                SchoolNumber=schoolNumber,
                PhoneNumber=phoneNumber
            };

            // Act
            UpdateStudentCommandValidator validator = new UpdateStudentCommandValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            // Arrange
            UpdateStudentCommand command = new UpdateStudentCommand(null,null);
            command.StudentId = 1;
            command.Model = new UpdateStudentViewModel()
            {
                FirstName = "testFirstName",
                LastName = "testLastName",
                IdentityNumber="10218736891",
                Class="B",
                DateOfBirth = new DateTime(2002,09,11),
                Gender = "K",
                Email = "test@gmail.com",
                SchoolNumber="76542",
                PhoneNumber="0000000000000"
            };

            // Act
            UpdateStudentCommandValidator validator = new UpdateStudentCommandValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count.Should().Be(0);
        }
   

    }
}