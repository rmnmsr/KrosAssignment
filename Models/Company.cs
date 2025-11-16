namespace KrosAssignment.Models;

public class Company
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    public int LeaderId { get; set; }
    public Employee Leader { get; set; } = null!;

    public List<Division> Divisions { get; set; } = new();
}
