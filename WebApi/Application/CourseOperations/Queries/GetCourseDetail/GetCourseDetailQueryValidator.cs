using FluentValidation;


namespace WebApi.Application.CourseOperations.Commands.GetCourseDetail{
    public class GetCourseDetailQueryValidator : AbstractValidator<GetCourseDetailQuery>
    {
        public GetCourseDetailQueryValidator()
        {
            RuleFor(query => query.CourseId).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}