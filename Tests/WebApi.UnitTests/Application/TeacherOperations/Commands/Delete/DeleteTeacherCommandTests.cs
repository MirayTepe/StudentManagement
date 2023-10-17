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
    public class DeleteTeacherCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _context;

        public DeleteTeacherCommandTests(CommonTestFixture commonTestFixture)
        {
            _context = commonTestFixture.Context;
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(99999)]
        public void WhenGivenTeacherIdIsNotExist_InvalidOperationException_ShouldBeReturn(int teacherId)
        {
            // Arrange (preparation)
            DeleteTeacherCommand command = new DeleteTeacherCommand(_context);
            command.TeacherId = teacherId;

            // Act & Assert (run and confirmation)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinmek istenen öğretmen bulunamadı!");
        }

        [Theory]
        [InlineData(3)]
        [InlineData(1)]
        public void WhenValidInputsAreGiven_Student_ShouldBeDeleted(int teacherId)
        {
            // Arrange (preparation)
            DeleteTeacherCommand command = new DeleteTeacherCommand(_context);
            command.TeacherId = teacherId;

            // Act
            FluentActions
                .Invoking(() => command.Handle()).Invoke();
             
            // Assert 
            var teacher = _context.Teachers.SingleOrDefault(x => x.Id == teacherId);
           
            teacher.Should().BeNull();
        }
    }
}
