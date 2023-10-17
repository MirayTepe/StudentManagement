using FluentValidation;
namespace WebApi.Application.StudentOperations.Commands.CreateStudent
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {
           RuleFor(command => command.Model.IdentityNumber).MinimumLength(10).NotNull();    RuleFor(command => command.Model.FirstName).MinimumLength(2).NotNull();
           RuleFor(command => command.Model.LastName).MinimumLength(2).NotNull();
           RuleFor(command => command.Model.Class).NotNull();
           RuleFor(command => command.Model.PhoneNumber).MinimumLength(11).NotNull();
           RuleFor(command => command.Model.DateOfBirth).NotNull();

           
        }
    }
}