using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.StudentOperations.Commands.DeleteStudent;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.StudentOpreations.Commands.Delete
{
    public class DeleteStudentCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(-999)]
        [InlineData(0)]
        [InlineData(-1)]
        //[InlineData(1)]
        public void WhenLowerThanAndEqualToZeroIdIsGiven_Validator_ShouldBeReturnError(int studentId)
        {
            //Arrange
            DeleteStudentCommand command=new DeleteStudentCommand(null);
            command.StudentId=studentId;

            //Act
            DeleteStudentCommandValidator validator=new DeleteStudentCommandValidator();
            var result=validator.Validate(command);

            //Assert
            result.Errors.Count.Should().BeGreaterThan(0);

        } 
        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturn()
        {
           //Arrange
            DeleteStudentCommand command=new DeleteStudentCommand(null);
            command.StudentId=1;

            //Act
            DeleteStudentCommandValidator validator=new DeleteStudentCommandValidator();
            var result=validator.Validate(command);

            //Assert
            result.Errors.Count.Should().Be(0);


        }

    }
} 