namespace KrosAssignment.Models;

public class Division
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    public int? LeaderId { get; set; }
    public Employee? Leader { get; set; }

    public int CompanyId { get; set; }
    public Company? Company { get; set; }

    public List<Project> Projects { get; set; } = new();
}
