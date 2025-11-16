namespace KrosAssignment.Models;

public class Employee
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }
}
