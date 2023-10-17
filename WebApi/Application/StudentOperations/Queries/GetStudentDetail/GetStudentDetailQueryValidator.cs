using FluentValidation;

namespace WebApi.Application.StudentOperations.Queries.GetStudentDetail
{
    public class GetStudentDetailQueryValidator : AbstractValidator<GetStudentDetailQuery>
    {
        public GetStudentDetailQueryValidator()
        {
            RuleFor(query => query.StudentId).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}