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
    public class DeleteStudentCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _context;

        public DeleteStudentCommandTests(CommonTestFixture commonTestFixture)
        {
            _context = commonTestFixture.Context;
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(99999)]
        public void WhenGivenStudentIdIsNotExist_InvalidOperationException_ShouldBeReturn(int studentId)
        {
            // Arrange (preparation)
            DeleteStudentCommand command = new DeleteStudentCommand(_context);
            command.StudentId = studentId;

            // Act & Assert (run and confirmation)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinmek istenen öğrenci bulunamadı!");
        }

        [Theory]
        [InlineData(3)]
        [InlineData(1)]
        public void WhenValidInputsAreGiven_Student_ShouldBeDeleted(int studentId)
        {
            // Arrange (preparation)
            DeleteStudentCommand command = new DeleteStudentCommand(_context);
            command.StudentId = studentId;

            // Act
            FluentActions
                .Invoking(() => command.Handle()).Invoke();
             
            // Assert 
            var student = _context.Students.SingleOrDefault(x => x.Id == studentId);
            student.Should().BeNull();
        }
    }
}
