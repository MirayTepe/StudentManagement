using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.StudentOperations.Commands.DeleteStudent;
using WebApi.Application.TeacherOperations.Commands.DeleteTeacher;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.TeacherOperations.Commands.Delete
{
    public class DeleteTeacherCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(-999)]
        [InlineData(0)]
        [InlineData(-1)]
        //[InlineData(1)]
        public void WhenLowerThanAndEqualToZeroIdIsGiven_Validator_ShouldBeReturnError(int teacherId)
        {
            //Arrange
            DeleteTeacherCommand command=new DeleteTeacherCommand(null);
            command.TeacherId=teacherId;

            //Act
            DeleteTeacherCommandValidator validator=new DeleteTeacherCommandValidator();
            var result=validator.Validate(command);

            //Assert
            result.Errors.Count.Should().BeGreaterThan(0);

        } 
        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturn()
        {
           //Arrange
           DeleteTeacherCommand command=new DeleteTeacherCommand(null);
            command.TeacherId=1;

            //Act
            DeleteTeacherCommandValidator validator=new DeleteTeacherCommandValidator();
            var result=validator.Validate(command);

            //Assert
            result.Errors.Count.Should().Be(0);


        }

    }
} 