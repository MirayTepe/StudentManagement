using FluentValidation;

namespace WebApi.Application.EnrolmenttOperations.Queries.GetEnrollmentDetail
{
    public class GetEnrollmentDetailQueryValidator : AbstractValidator<GetEnrollmentDetailQuery>
    {
        public GetEnrollmentDetailQueryValidator()
        {
            RuleFor(query => query.EnrollmentId).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}