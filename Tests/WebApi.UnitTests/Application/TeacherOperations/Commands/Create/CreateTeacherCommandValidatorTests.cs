using FluentAssertions;
using WebApi.Application.StudentOperations.Commands.CreateStudent;
using WebApi.Application.TeacherOperations.Commands.CreateTeacher;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.TeacherOperations.Commands.Create
{
    public class CreateTeacherCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
       
        [InlineData("", "", "", "", "", "")]
  
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErorrs(string firstName, string lastName,string email,string identityNumber,string phoneNumber,string subject)
        {
            //arrange
            CreateTeacherCommand command = new CreateTeacherCommand(null,null);
            command.Model = new CreateTeacherViewModel()
            {
                FirstName = firstName,
                LastName = lastName,
                Email=email,
                IdentityNumber=identityNumber,
                Subject=subject,
                PhoneNumber=phoneNumber
            };

            //act
            CreateTeacherCommandValidator validator = new CreateTeacherCommandValidator();
            var results = validator.Validate(command);

            //assert
            results.Errors.Count.Should().BeGreaterThan(0);
        }

        

        
    }
}