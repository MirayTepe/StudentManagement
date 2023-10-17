using AutoMapper;
using FluentAssertions;
using WebApi.Application.EnrollmentOperations.Commands.CreateEnrollment;
using WebApi.Application.EnrollmentOperations.Commands.UpdateEnrollment;
using WebApi.Application.EnrolmenttOperations.Queries.GetEnrollmentDetail;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.EnrollmentOperations.Queries.GetEnrollmentDetail
{
    public class GetEnrollmentDetailQueryTests: IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _context;
        private readonly IMapper _mapper;
        public GetEnrollmentDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Theory]
        //[InlineData(1)]
        [InlineData(55)]
        [InlineData(9999)]
        public void WhenEnrollmentIdIsNotFound_InvalidOperationException_ShouldReturnError(int id)
        {
            GetEnrollmentDetailQuery query = new GetEnrollmentDetailQuery(_context, _mapper);
            query.EnrollmentId = id;
            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kayıt bulunamadı!");

        }
    }
}