using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.StudentOperations.Commands.UpdateStudent;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.StudentOpreations.Commands.Update
{
    public class UpdateStudentCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _context;
        private readonly IMapper _mapper;


        public UpdateStudentCommandTests(CommonTestFixture commonTestFixture)
        {
            _context = commonTestFixture.Context;
            _mapper = commonTestFixture.Mapper;
        }
        [Fact]
        public void WhenValidInputsAreGiven_Student_ShouldBeUpdated()
        {
            // Arrange (preparation)
            int studentId=3;
          
            UpdateStudentCommand command = new UpdateStudentCommand(_context,_mapper);
            UpdateStudentViewModel model = new UpdateStudentViewModel
            {
             
                FirstName = "UpdateFirstName",
                LastName = "UpdateLastName",
                DateOfBirth = new DateTime(2002,08,14),
                Email = "test@gmail.com",
                IdentityNumber="10218736891",
                Gender = "K",
                Class="B",
                SchoolNumber="76542",
                PhoneNumber="00000000000"

            };
            command.Model = model;
          
            command.StudentId =studentId;
            
            

            // Act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // Assert
            var updatedStudent = _context.Students.SingleOrDefault(s=>s.Id==studentId);

            updatedStudent.Should().NotBeNull();
            updatedStudent.FirstName.Should().Be(model.FirstName);
            updatedStudent.LastName.Should().Be(model.LastName);
            updatedStudent.DateOfBirth.Should().Be(model.DateOfBirth);
            updatedStudent.Email.Should().Be(model.Email);
            updatedStudent.IdentityNumber.Should().Be(model.IdentityNumber);
            updatedStudent.Gender.Should().Be(model.Gender);
            updatedStudent.Class.Should().Be(model.Class);
            updatedStudent.SchoolNumber.Should().Be(model.SchoolNumber);
            updatedStudent.PhoneNumber.Should().Be(model.PhoneNumber);
           
            
        }
        [Theory]
        //[InlineData(1)]
        //[InlineData(4)]
        [InlineData(55)]
        [InlineData(-2)] 
        public void WhenGivenStudentIdIsNotExist_InvalidOperationException_ShouldBeReturnErrors(int id)
        {
            // Arrange
            UpdateStudentCommand command = new UpdateStudentCommand(_context,_mapper);
            command.StudentId = id;
            command.Model = new UpdateStudentViewModel();

            // Act and Assert
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Öğrenci bulunamadı!");
        }

        

    }
}