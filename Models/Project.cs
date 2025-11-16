namespace KrosAssignment.Models;

public class Project
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    public int LeaderId { get; set; }
    public Employee Leader { get; set; } = null!;

    public int DivisionId { get; set; }
    public Division? Division { get; set; }

    public List<Department> Departments { get; set; } = new();
}
