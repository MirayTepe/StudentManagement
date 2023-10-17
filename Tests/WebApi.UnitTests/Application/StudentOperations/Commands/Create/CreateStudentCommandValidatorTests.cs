using FluentAssertions;
using WebApi.Application.StudentOperations.Commands.CreateStudent;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.StudentOpreations.Commands.Create
{
    public class CreateStudentCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
       
        [InlineData("", "", "2002-09-12", "", "", "", "", "", "")]
  
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErorrs(string firstName, string lastName,string dateOfBirth, string email,string identityNumber,string gender,string courseClass,string schoolNumber,string phoneNumber)
        {
            //arrange
            CreateStudentCommand command = new CreateStudentCommand(null,null);
            command.Model = new CreateStudentViewModel()
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth=DateTime.Parse(dateOfBirth),
                Email=email,
                IdentityNumber=identityNumber,
                Gender=gender,
                Class=courseClass,
                SchoolNumber=schoolNumber,
                PhoneNumber=phoneNumber
            };

            //act
            CreateStudentCommandValidator validator = new CreateStudentCommandValidator();
            var results = validator.Validate(command);

            //assert
            results.Errors.Count.Should().BeGreaterThan(0);
        }

        

        
    }
}