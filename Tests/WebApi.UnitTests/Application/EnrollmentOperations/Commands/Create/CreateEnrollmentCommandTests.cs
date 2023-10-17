using AutoMapper;
using FluentAssertions;
using WebApi.Application.EnrollmentOperations.Commands.CreateEnrollment;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.EnrollmentOperations.Commands.Create
{
    public class CreateEnrollmentCommandTests: IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateEnrollmentCommandTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        
         [Fact]
        public void WhenAlreadyExistCourseIdInModelIsGiven_InvalidOperationException_ShouldBeReturnError()
        {
            //arrange
            CreateEnrollmentViewModel model = new CreateEnrollmentViewModel() {CourseId=0,StudentId=1};

            //act
            CreateEnrollmentCommand command = new CreateEnrollmentCommand(_dbContext, _mapper);
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
            CreateEnrollmentViewModel model = new CreateEnrollmentViewModel() {CourseId=1,StudentId=0};

            //act
            CreateEnrollmentCommand command = new CreateEnrollmentCommand(_dbContext, _mapper);
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
             CreateEnrollmentViewModel model = new CreateEnrollmentViewModel() {CourseId=1,StudentId=1};

            //act
            CreateEnrollmentCommand command = new CreateEnrollmentCommand(_dbContext, _mapper);
            command.Model = model;
            
            //assert
            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Bu kayıt daha önce  yapılmıştır!");
        }


        
        [Fact]
        public void WhenNotExistCourseAndStudentIdIsGiven_Create_ShouldBeCreateEnrollment()
        {
           
            //arrange
             CreateEnrollmentViewModel model = new CreateEnrollmentViewModel() {CourseId=1,StudentId=3};

            //act
            CreateEnrollmentCommand command = new CreateEnrollmentCommand(_dbContext, _mapper);
            command.Model = model;
        
            
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