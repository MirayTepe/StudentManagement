using FluentValidation;


namespace WebApi.Application.EnrollmentOperations.Commands.UpdateEnrollment
{
    public class UpdateEnrollmentCommandValidator : AbstractValidator<UpdateEnrollmentCommand>
    {
        public UpdateEnrollmentCommandValidator()
        {
           RuleFor(command => command.Model.CourseId).GreaterThan(0).NotNull();
           RuleFor(command => command.Model.StudentId).GreaterThan(0).NotNull();

           
        }
    }
}