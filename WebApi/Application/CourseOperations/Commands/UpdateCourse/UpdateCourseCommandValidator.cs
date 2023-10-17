using FluentValidation;

namespace WebApi.Application.CourseOperations.Commands.UpdateCourse
{
    public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
    {
        public UpdateCourseCommandValidator()
        {
            RuleFor(command => command.CourseId).GreaterThan(0).NotEmpty().NotNull(); 
            RuleFor(command => command.Model.TeacherId).GreaterThan(0).NotEmpty().NotNull(); 
            RuleFor(command => command.Model.CourseName).MinimumLength(2).NotEmpty().NotNull(); 
            RuleFor(command => command.Model.CourseCode).MinimumLength(2).NotEmpty().NotNull(); 
            RuleFor(command => command.Model.Description).MinimumLength(2).NotEmpty().NotNull(); 
            RuleFor(command => command.Model.Schedule).MinimumLength(10).NotEmpty().NotNull();
        }
    }
}