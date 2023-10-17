using FluentValidation;


namespace WebApi.Application.EnrollmentOperations.Commands.CreateEnrollment
{
    public class CreateEnrollmentCommandValidator : AbstractValidator<CreateEnrollmentCommand>
    {
        public CreateEnrollmentCommandValidator()
        {
           RuleFor(command => command.Model.CourseId).GreaterThan(0).NotNull();
           RuleFor(command => command.Model.StudentId).GreaterThan(0).NotNull();

           
        }
    }
}