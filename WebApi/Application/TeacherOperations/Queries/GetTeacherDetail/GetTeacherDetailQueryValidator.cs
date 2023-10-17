using FluentValidation;


namespace WebApi.Application.TeacherOperations.Queries.GetTeacherDetail{
    public class GetTeacherDetailQueryValidator : AbstractValidator<GetTeacherDetailQuery>
    {
        public GetTeacherDetailQueryValidator()
        {
            RuleFor(query => query.TeacherId).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}