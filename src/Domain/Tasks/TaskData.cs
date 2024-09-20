namespace Domain.Tasks;

public class TaskData
{
    public Guid? Id { get; set; }
    public string? Description { get; set; }
    public bool? Completed { get; set; }
    public DateTime? Created { get; set; }
    public DateTime? Updated { get; set; }

    public TaskData() { }

    public TaskData(Task task)
    {
        Id = task.Id;
        Description = task.Description;
        Completed = task.Completed;
        Created = task.Created;
        Updated = task.Updated;
    }
}