using AutoMapper;
using FluentAssertions;
using WebApi.Application.CourseOperations.Commands.CreateCourse;
using WebApi.Application.CourseOperations.Commands.DeleteCourse;
using WebApi.Application.CourseOperations.Commands.GetCourseDetail;
using WebApi.Application.CourseOperations.Commands.UpdateCourse;
using WebApi.Application.StudentOperations.Queries.GetStudentDetail;
using WebApi.Application.TeacherOperations.Queries.GetTeacherDetail;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.TeacherOperations.Queries.GetById
{
    public class GetTeacherDetailQueryTests: IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _context;
        private readonly IMapper _mapper;
        public GetTeacherDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Theory]
        //[InlineData(1)]
        [InlineData(55)]
        [InlineData(9999)]
        public void WhenTeacherIdIsNotFound_InvalidOperationException_ShouldReturnError(int id)
        {
            GetTeacherDetailQuery query = new GetTeacherDetailQuery(_context, _mapper);
            query.TeacherId = id;
            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu öğretmenin kaydı bulunamadı!");

        }

    }
}