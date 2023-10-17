using AutoMapper;
using FluentAssertions;
using WebApi.Application.EnrollmentOperations.Commands.DeleteEnrollment;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.EnrollmentOperations.Commands.Delete
{
    public class DeleteEnrollmentCommandTest: IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _dbContext;
        private readonly IMapper _mapper;
        public DeleteEnrollmentCommandTest(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenNotExistEnrollmentIsGiven_InvalidOperationException_ShouldBeReturnErrors()
        {
            // Given
            DeleteEnrollmentCommand command = new DeleteEnrollmentCommand(_dbContext);
            command.EnrollmentId = 0;
        
            // When // Then
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Silinmek istenen kayıt bulunamadı!");                    
        }
        [Theory]
        [InlineData(3)]
        [InlineData(1)]
        public void WhenValidInputsAreGiven_Enrollment_ShouldBeDeleted(int enrollmentId)
        {
            // Arrange (preparation)
            DeleteEnrollmentCommand command = new DeleteEnrollmentCommand(_dbContext);
            command.EnrollmentId = enrollmentId;

            // Act
            FluentActions
                .Invoking(() => command.Handle()).Invoke();
             
            // Assert 
            var enrollment = _dbContext.Enrollments.SingleOrDefault(x => x.Id == enrollmentId);
            enrollment.Should().BeNull();
        }


    }
}