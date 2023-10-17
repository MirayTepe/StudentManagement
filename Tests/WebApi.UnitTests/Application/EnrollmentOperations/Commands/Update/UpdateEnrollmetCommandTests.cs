using AutoMapper;
using FluentAssertions;
using WebApi.Application.EnrollmentOperations.Commands.CreateEnrollment;
using WebApi.Application.EnrollmentOperations.Commands.UpdateEnrollment;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.EnrollmentOperations.Commands.Update
{
    public class UpdateEnrollmetCommandTests: IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _dbContext;
        private readonly IMapper _mapper;
        public UpdateEnrollmetCommandTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        
         [Fact]
        public void WhenAlreadyExistCourseIdInModelIsGiven_InvalidOperationException_ShouldBeReturnError()
        {
            //arrange
            UpdateEnrollmentViewModel model = new UpdateEnrollmentViewModel() {CourseId=0,StudentId=1};

            //act
            UpdateEnrollmentCommand command = new UpdateEnrollmentCommand(_dbContext, _mapper);
            command.Model = model;
            

            //assert
            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Ders  kaydı bulunamadı!");
        }
         [Fact]
        public void WhenNotExistStudentIdInModelIsGiven_InvalidOperationException_ShouldBeReturnError()
        {
            //arrange
            UpdateEnrollmentViewModel model = new UpdateEnrollmentViewModel() {CourseId=1,StudentId=0};

            //act
            UpdateEnrollmentCommand command = new UpdateEnrollmentCommand(_dbContext, _mapper);
            command.Model = model;
            

            //assert
            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Öğrenci bulunamadı!");
        }
         [Fact]
        public void WhenAlreadyExistCourseAndStudentIdInModelIsGiven_InvalidOperationException_ShouldBeReturnError()
        {
            //arrange
             UpdateEnrollmentViewModel model = new UpdateEnrollmentViewModel() {CourseId=1,StudentId=1};

            //act
            UpdateEnrollmentCommand command = new UpdateEnrollmentCommand(_dbContext, _mapper);
            command.Model = model;
            
            //assert
            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Kayıt bulunamadı!");
        }


        
        [Fact]
        public void WhenNotExistCourseAndStudentIdIsGiven_Create_ShouldBeCreateEnrollment()
        {
           
            //arrange
             UpdateEnrollmentViewModel model = new UpdateEnrollmentViewModel() {CourseId=1,StudentId=3};

            //act
            UpdateEnrollmentCommand command = new UpdateEnrollmentCommand(_dbContext, _mapper);
            command.Model = model;
            command.EnrollmentId=1;
        
            
            FluentActions
                .Invoking(()=> command.Handle()).Invoke();
        
            // assert
            var enrollment = _dbContext.Enrollments.SingleOrDefault(s => s.CourseId == model.CourseId && s.StudentId == model.StudentId);
            
            enrollment.Should().NotBeNull();
            enrollment.CourseId.Should().Be(model.CourseId);
            enrollment.StudentId.Should().Be(model.StudentId);
           
        }
    }
}
