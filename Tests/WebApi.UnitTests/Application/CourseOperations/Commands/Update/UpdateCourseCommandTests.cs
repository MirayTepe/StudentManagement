using AutoMapper;
using FluentAssertions;
using WebApi.Application.CourseOperations.Commands.CreateCourse;
using WebApi.Application.CourseOperations.Commands.DeleteCourse;
using WebApi.Application.CourseOperations.Commands.UpdateCourse;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.CourseOperations.Commands.Update
{
    public class UpdateCourseCommandTests: IClassFixture<CommonTestFixture>
    {
         private readonly StudentManagementDbContext _context;
        private readonly IMapper _mapper;


        public UpdateCourseCommandTests(CommonTestFixture commonTestFixture)
        {
            _context = commonTestFixture.Context;
            _mapper = commonTestFixture.Mapper;
        }
         [Theory]
        //[InlineData(1)]
        [InlineData(55)]
        [InlineData(-2)] 
        public void WhenGivenCourseIdIsNotExist_InvalidOperationException_ShouldBeReturnErrors(int id){
            

          
            UpdateCourseCommand command = new UpdateCourseCommand(_context, _mapper);
            command.CourseId=id;
            UpdateCourseViewModel model = new UpdateCourseViewModel() {  TeacherId= 1};

            command.Model = model;
            

        
            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Ders bulunamadı!");

        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)] 
        public void WhenGivenTeacherIdIsNotExist_InvalidOperationException_ShouldBeReturnErrors(int id){
            

          
            UpdateCourseCommand command = new UpdateCourseCommand(_context, _mapper);
            command.CourseId=id;
            UpdateCourseViewModel model = new UpdateCourseViewModel() { TeacherId= 0};

            command.Model = model;
            

        
            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Öğretmen kaydı bulunamadı!");

        }

        [Fact]
        public void WhenValidInputsAreGiven_Course_ShouldBeUpdated()
        {
            // Arrange (preparation)
            int courseId = 5;
            UpdateCourseCommand command = new UpdateCourseCommand(_context,_mapper);
            UpdateCourseViewModel model = new UpdateCourseViewModel() {CourseName = "Bilgi Sistemleri Güvenliği", TeacherId = 4, CourseCode = "TEST105",Description="D-303'de yapılacak.",Schedule="Cuma 8:30"};
            command.Model = model;
            command.CourseId = courseId;

            // Act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // Assert
            var course = _context.Courses.SingleOrDefault(x => x.Id == courseId);

            course.Should().NotBeNull();
            course.CourseName.Should().Be(model.CourseName);
            course.TeacherId.Should().Be(model.TeacherId);
            course.CourseCode.Should().Be(model.CourseCode);
            course.Description.Should().Be(model.Description); 
            course.Schedule.Should().Be(model.Schedule);
        }

    }
}