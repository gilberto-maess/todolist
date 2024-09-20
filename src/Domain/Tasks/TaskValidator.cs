using FluentValidation;

namespace Domain.Tasks;

public class TaskValidator : AbstractValidator<Task>
{
    public TaskValidator()
    {
        RuleFor(task => task.Id)
            .NotEmpty()
            .WithMessage("O campo id é obrigatório");

        RuleFor(task => task.Description)
            .NotEmpty()
            .WithMessage("O campo description é obrigatório");

        RuleFor(task => task.Description)
            .MaximumLength(255)
            .WithMessage("O campo description não pode possuir mais de 255 caracteres");

        RuleFor(task => task.Description)
            .MinimumLength(5)
            .WithMessage("O campo description precisa possuir mais de 5 caracteres");
    }
}