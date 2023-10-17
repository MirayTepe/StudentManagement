using AutoMapper;
using FluentAssertions;
using WebApi.Application.CourseOperations.Commands.CreateCourse;
using WebApi.Application.StudentOperations.Commands.CreateStudent;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.StudentOpreations.Commands.Create
{
    public class CreateStudentCommandTests: IClassFixture<CommonTestFixture>
  { 
        private readonly StudentManagementDbContext _context;
        private readonly IMapper _mapper;


        public CreateStudentCommandTests(CommonTestFixture commonTestFixture)
        {
            _context = commonTestFixture.Context;
            _mapper = commonTestFixture.Mapper;
        }
         [Fact]
        public void WhenStudentModelIsGiven_Create_ShouldBeCreateCourse()
        {
            // Arrange
            var model = new CreateStudentViewModel()
            {
                FirstName = "testFirstName",
                LastName = "testLastName",
                DateOfBirth = new DateTime(2002,08,14),
                Email = "test@gmail.com",
                IdentityNumber="10218736891",
                Gender = "K",
                Class="B",
                SchoolNumber="76542",
                PhoneNumber="00000000000"


            };

            var command = new CreateStudentCommand(_context, _mapper);
            command.Model = model;

            // Act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // Assert
            var student = _context.Students.SingleOrDefault(s => s.SchoolNumber == model.SchoolNumber );

            student.Should().NotBeNull();
            student.FirstName.Should().Be(model.FirstName);
            student.LastName.Should().Be(model.LastName);
            student.DateOfBirth.Should().Be(model.DateOfBirth);
            student.Email.Should().Be(model.Email);
            student.IdentityNumber.Should().Be(model.IdentityNumber);
            student.Gender.Should().Be(model.Gender);
            student.Class.Should().Be(model.Class);
            student.SchoolNumber.Should().Be(model.SchoolNumber);
            student.PhoneNumber.Should().Be(model.PhoneNumber);
        }
        

   }

}
