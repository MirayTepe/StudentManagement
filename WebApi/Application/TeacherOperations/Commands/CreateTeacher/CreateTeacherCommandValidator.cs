using FluentValidation;


namespace WebApi.Application.TeacherOperations.Commands.CreateTeacher
{
    public class CreateTeacherCommandValidator : AbstractValidator<CreateTeacherCommand>
    {
        public CreateTeacherCommandValidator()
        {
           RuleFor(command => command.Model.IdentityNumber).MinimumLength(10).NotNull();    
           RuleFor(command => command.Model.FirstName).MinimumLength(2).NotNull();
           RuleFor(command => command.Model.LastName).MinimumLength(2).NotNull();
           RuleFor(command => command.Model.Email).NotNull();
           RuleFor(command => command.Model.PhoneNumber).MinimumLength(11).NotNull();
           RuleFor(command => command.Model.Subject).NotNull();

           
        }
    }
}