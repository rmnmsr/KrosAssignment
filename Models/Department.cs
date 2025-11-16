namespace KrosAssignment.Models;

public class Department
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    public int? LeaderId { get; set; }
    public Employee? Leader { get; set; }

    public int ProjectId { get; set; }
    public Project? Project { get; set; }

    public List<Employee> Employees { get; set; } = new();
}
