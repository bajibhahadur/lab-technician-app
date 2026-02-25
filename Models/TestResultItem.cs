namespace LabTechnicianApp.Models;
public class TestResultItem {
    public int Id { get; set; }
    public int TestResultId { get; set; }
    public int TestParameterId { get; set; }
    public string Value { get; set; } = string.Empty;
    public TestParameter? TestParameter { get; set; }
}
