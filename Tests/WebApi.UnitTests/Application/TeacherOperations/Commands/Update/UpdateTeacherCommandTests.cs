using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.StudentOperations.Commands.UpdateStudent;
using WebApi.Application.TeacherOperations.Commands.UpdateTeacher;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.TeacherOperations.Commands.Update
{
    public class UpdateTeacherCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _context;
        private readonly IMapper _mapper;


        public UpdateTeacherCommandTests(CommonTestFixture commonTestFixture)
        {
            _context = commonTestFixture.Context;
            _mapper = commonTestFixture.Mapper;
        }
        [Fact]
        public void WhenValidInputsAreGiven_Student_ShouldBeUpdated()
        {
            // Arrange (preparation)
            int courseId=3;
          
            UpdateTeacherCommand command = new UpdateTeacherCommand(_context,_mapper);
            UpdateTeacherViewModel model = new UpdateTeacherViewModel
            {
             
                FirstName = "UpdateFirstName",
                LastName = "UpdateLastName",
                Email = "test@gmail.com",
                IdentityNumber="10218736891",
                Subject="Test",
                PhoneNumber="00000000000"

            };
            command.Model = model;
          
            command.TeacherId =courseId;
            
            

            // Act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // Assert
            var updatedTeacher = _context.Teachers.SingleOrDefault(s=>s.Id==courseId);

            updatedTeacher.Should().NotBeNull();
            updatedTeacher.FirstName.Should().Be(model.FirstName);
            updatedTeacher.LastName.Should().Be(model.LastName);
            updatedTeacher.Email.Should().Be(model.Email);
            updatedTeacher.IdentityNumber.Should().Be(model.IdentityNumber);
            updatedTeacher.Subject.Should().Be(model.Subject);
            updatedTeacher.PhoneNumber.Should().Be(model.PhoneNumber);
           
            
        }
        [Theory]
        //[InlineData(1)]
        //[InlineData(4)]
        [InlineData(55)]
        [InlineData(-2)] 
        public void WhenGivenTeacherIdIsNotExist_InvalidOperationException_ShouldBeReturnErrors(int id)
        {
            // Arrange
            UpdateTeacherCommand command = new UpdateTeacherCommand(_context,_mapper);
            command.TeacherId = id;
            command.Model = new UpdateTeacherViewModel();

            // Act and Assert
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Öğretmen bulunamadı!");
        }

        

    }
}