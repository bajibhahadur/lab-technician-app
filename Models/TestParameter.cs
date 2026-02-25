namespace LabTechnicianApp.Models;
public class TestParameter {
    public int Id { get; set; }
    public int TestTypeId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Unit { get; set; } = string.Empty;
    public string ReferenceRange { get; set; } = string.Empty;
    public TestType? TestType { get; set; }
}
