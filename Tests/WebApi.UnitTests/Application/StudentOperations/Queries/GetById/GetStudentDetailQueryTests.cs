using AutoMapper;
using FluentAssertions;
using WebApi.Application.CourseOperations.Commands.CreateCourse;
using WebApi.Application.CourseOperations.Commands.DeleteCourse;
using WebApi.Application.CourseOperations.Commands.GetCourseDetail;
using WebApi.Application.CourseOperations.Commands.UpdateCourse;
using WebApi.Application.StudentOperations.Queries.GetStudentDetail;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.StudentOpreations.Queries.GetById
{
    public class GetStudentDetailQueryTests: IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _context;
        private readonly IMapper _mapper;
        public GetStudentDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Theory]
        //[InlineData(1)]
        [InlineData(55)]
        [InlineData(9999)]
        public void WhenStudentIdIsNotFound_InvalidOperationException_ShouldReturnError(int id)
        {
            GetStudentDetailQuery query = new GetStudentDetailQuery(_context, _mapper);
            query.StudentId = id;
            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu öğrenci kaydı bulunamadı!");

        }

    }
}