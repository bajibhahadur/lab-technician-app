namespace LabTechnicianApp.Models;
public class TestResult {
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int TestTypeId { get; set; }
    public DateTime TestDate { get; set; }
    public Patient? Patient { get; set; }
    public TestType? TestType { get; set; }
    public List<TestResultItem> Items { get; set; } = new();
}
