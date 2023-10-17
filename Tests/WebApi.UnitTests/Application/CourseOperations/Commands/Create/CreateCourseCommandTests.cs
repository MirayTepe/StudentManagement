using AutoMapper;
using FluentAssertions;
using WebApi.Application.CourseOperations.Commands.CreateCourse;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.CourseOperations.Commands.Create
{
    public class CreateCourseCommandTests: IClassFixture<CommonTestFixture>
{
        private readonly StudentManagementDbContext _context;
        private readonly IMapper _mapper;


        public CreateCourseCommandTests(CommonTestFixture commonTestFixture)
        {
            _context = commonTestFixture.Context;
            _mapper = commonTestFixture.Mapper;
        }
         [Fact]
        public void WhenCourseModelIsGiven_Create_ShouldBeCreateCourse()
        {
            // Arrange
            var model = new CreateCourseViewModel()
            {
                CourseName = "testCourseName",
                CourseCode = "testCourseCode",
                TeacherId = 4,
                Description = "tesssssst",
                Schedule = "Salı 8:15"
            };

            var command = new CreateCourseCommand(_context, _mapper);
            command.Model = model;

            // Act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // Assert
            var course = _context.Courses.SingleOrDefault(s => s.CourseName == model.CourseName && s.CourseCode == model.CourseCode && s.TeacherId == model.TeacherId && s.Description == model.Description && s.Schedule == model.Schedule);

            course.Should().NotBeNull();
            course.TeacherId.Should().Be(model.TeacherId);
            course.CourseCode.Should().Be(model.CourseCode);
            course.CourseName.Should().Be(model.CourseName);
            course.Description.Should().Be(model.Description);
            course.Schedule.Should().Be(model.Schedule);
        }
        

   }

}
