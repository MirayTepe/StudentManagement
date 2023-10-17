using FluentValidation;

namespace WebApi.Application.StudentOperations.Commands.UpdateStudent
{
    public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidator()
        {
           RuleFor(command => command.StudentId).GreaterThan(0).NotNull();
           RuleFor(command => command.Model.FirstName).NotEmpty().NotNull();
           RuleFor(command => command.Model.LastName).NotEmpty().NotNull();
           RuleFor(command => command.Model.Email).NotEmpty().NotNull();
      
      

           
        }
    }
}