using FluentValidation;


namespace WebApi.Application.EnrollmentOperations.Commands.DeleteEnrollment
{
    public class DeleteEnrollmentCommandValidator : AbstractValidator<DeleteEnrollmentCommand>
    {
        public DeleteEnrollmentCommandValidator()
        {
           RuleFor(command => command.EnrollmentId).GreaterThan(0).NotNull();
      
      

           
        }
    }
}