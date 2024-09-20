using Domain.Exceptions;
using FluentValidation.Results;

namespace Domain.Tasks;

public class Task
{
    public Guid Id { get; private set; }
    public string Description { get; private set; } = null!;
    public bool Completed { get; private set; }
    public DateTime Created { get; private set; }
    public DateTime? Updated { get; private set; }
    public bool IsValid { get; private set; }
    public ValidationResult? ValidationResult { get; private set; }

    private Task() { }

    public Task(TaskData taskData)
    {
        Id = taskData.Id!.Value;
        Description = taskData.Description!;
        Completed = taskData.Completed!.Value;
        Created = taskData.Created!.Value;
        Updated = taskData.Updated;

        ValidationResult = new TaskValidator().Validate(this);
        IsValid = ValidationResult.IsValid;

        if (!IsValid)
            throw new DomainException(ValidationResult);
    }

    public static Task Create(TaskData taskData)
    {
        Task task = new()
        {
            Id = Guid.NewGuid(),
            Description = taskData.Description!,
            Completed = false,
            Created = DateTime.UtcNow
        };

        task.ValidationResult = new TaskValidator().Validate(task);
        task.IsValid = task.ValidationResult.IsValid;

        if (!task.IsValid)
            throw new DomainException(task.ValidationResult);

        return task;
    }
}