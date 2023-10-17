using AutoMapper;
using FluentAssertions;
using WebApi.Application.CourseOperations.Commands.CreateCourse;
using WebApi.Application.CourseOperations.Commands.DeleteCourse;
using WebApi.Application.CourseOperations.Commands.GetCourseDetail;
using WebApi.Application.CourseOperations.Commands.UpdateCourse;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.CourseOperations.Queries.GetById
{
    public class GetCourseDetailQueryTests: IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _context;
        private readonly IMapper _mapper;
        public GetCourseDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Theory]
        //[InlineData(1)]
        [InlineData(55)]
        [InlineData(9999)]
        public void WhenCourseIdIsNotFound_InvalidOperationException_ShouldReturnError(int id)
        {
            GetCourseDetailQuery query = new GetCourseDetailQuery(_context, _mapper);
            query.CourseId = id;
            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu dersin kaydı bulunamadı!");

        }

    }
}