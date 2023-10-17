using FluentValidation;


namespace WebApi.Application.CourseOperations.Commands.CreateCourse
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
           RuleFor(command => command.Model.TeacherId).GreaterThan(0).NotNull();
           RuleFor(command => command.Model.CourseCode).MinimumLength(2).NotNull();
           RuleFor(command => command.Model.CourseName).MinimumLength(2).NotNull();
           RuleFor(command => command.Model.Description).MinimumLength(2).NotNull();
           RuleFor(command => command.Model.Schedule).MinimumLength(2).NotNull();
           
           
        }
    }
}