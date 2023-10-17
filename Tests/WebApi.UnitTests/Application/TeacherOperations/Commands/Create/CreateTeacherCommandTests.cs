using AutoMapper;
using FluentAssertions;
using WebApi.Application.CourseOperations.Commands.CreateCourse;
using WebApi.Application.StudentOperations.Commands.CreateStudent;
using WebApi.Application.TeacherOperations.Commands.CreateTeacher;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.TeacherOperations.Commands.Create
{
    public class CreateTeacherCommandTests: IClassFixture<CommonTestFixture>
  { 
        private readonly StudentManagementDbContext _context;
        private readonly IMapper _mapper;


        public CreateTeacherCommandTests(CommonTestFixture commonTestFixture)
        {
            _context = commonTestFixture.Context;
            _mapper = commonTestFixture.Mapper;
        }
         [Fact]
        public void WhenStudentModelIsGiven_Create_ShouldBeCreateCourse()
        {
            // Arrange
            var model = new CreateTeacherViewModel()
            {
                FirstName = "testFirstName",
                LastName = "testLastName",
                Email = "test@gmail.com",
                IdentityNumber="10218736891",
                PhoneNumber="00000000000",
                Subject="Test"


            };

            var command = new CreateTeacherCommand(_context, _mapper);
            command.Model = model;

            // Act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // Assert
            var teacher = _context.Teachers.SingleOrDefault(s => s.IdentityNumber==model.IdentityNumber);

            teacher.Should().NotBeNull();
            teacher.FirstName.Should().Be(model.FirstName);
            teacher.LastName.Should().Be(model.LastName);
            teacher.Email.Should().Be(model.Email);
            teacher.IdentityNumber.Should().Be(model.IdentityNumber);
            teacher.PhoneNumber.Should().Be(model.PhoneNumber);
            teacher.Subject.Should().Be(model.Subject);
        }
        

   }

}
