namespace LabTechnicianApp.Models;
public class TestType {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<TestParameter> Parameters { get; set; } = new();
}
