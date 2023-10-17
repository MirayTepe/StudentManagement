using FluentValidation;

namespace WebApi.Application.TeacherOperations.Commands.UpdateTeacher
{
    public class UpdateTeacherCommandValidator : AbstractValidator<UpdateTeacherCommand>
    {
        public UpdateTeacherCommandValidator()
        {
           RuleFor(command => command.TeacherId).GreaterThan(0).NotNull();
           RuleFor(command => command.Model.FirstName).MinimumLength(2).NotNull();
           RuleFor(command => command.Model.LastName).MinimumLength(2).NotNull();
      
      

           
        }
    }
}