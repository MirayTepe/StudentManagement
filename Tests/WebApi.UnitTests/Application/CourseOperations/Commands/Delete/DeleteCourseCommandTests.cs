using AutoMapper;
using FluentAssertions;
using WebApi.Application.CourseOperations.Commands.CreateCourse;
using WebApi.Application.CourseOperations.Commands.DeleteCourse;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.CourseOperations.Commands.Delete
{
    public class DeleteCourseCommandTests: IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _context;
        private readonly IMapper _mapper;


        public DeleteCourseCommandTests(CommonTestFixture commonTestFixture)
        {
            _context = commonTestFixture.Context;
            _mapper = commonTestFixture.Mapper;
        }
        [Theory]
        [InlineData(-5)]
        [InlineData(99999)]
        public void WhenGivenCourseIdIsNotExist_InvalidOperationException_ShouldBeReturn(int courseId)
        {
            // Arrange (preparation)
            DeleteCourseCommand command = new DeleteCourseCommand(_context);
            command.CourseId = courseId;

            // Act & Assert (run and confirmation)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinmek istenen ders bulunamadı!");
        }
        [Theory]
        [InlineData(3)]
        [InlineData(1)]
        public void WhenValidInputsAreGiven_Book_ShouldBeDeleted(int courseId)
        {
            // Arrange (preparation)
            DeleteCourseCommand command = new DeleteCourseCommand(_context);
            command.CourseId = courseId;

            // Act
            FluentActions
                .Invoking(() => command.Handle()).Invoke();
             
            // Assert 
            var course = _context.Courses.SingleOrDefault(x => x.Id == courseId);
            course.Should().BeNull();
        }

        

   }

}
