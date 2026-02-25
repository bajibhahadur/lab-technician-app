using Microsoft.EntityFrameworkCore;
using LabTechnicianApp.Models;

namespace LabTechnicianApp.Data;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<TestType> TestTypes => Set<TestType>();
    public DbSet<TestParameter> TestParameters => Set<TestParameter>();
    public DbSet<TestResult> TestResults => Set<TestResult>();
    public DbSet<TestResultItem> TestResultItems => Set<TestResultItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        // Seed TestTypes
        modelBuilder.Entity<TestType>().HasData(
            new TestType { Id = 1, Name = "Complete Blood Count (CBC)" },
            new TestType { Id = 2, Name = "Lipid Profile" },
            new TestType { Id = 3, Name = "Liver Function Test (LFT)" },
            new TestType { Id = 4, Name = "Kidney Function Test (KFT)" },
            new TestType { Id = 5, Name = "Urine Analysis" }
        );

        // Seed TestParameters - CBC
        modelBuilder.Entity<TestParameter>().HasData(
            new TestParameter { Id = 1, TestTypeId = 1, Name = "WBC", Unit = "10³/µL", ReferenceRange = "4.5-11.0" },
            new TestParameter { Id = 2, TestTypeId = 1, Name = "RBC", Unit = "10⁶/µL", ReferenceRange = "4.5-5.5 (M), 4.0-5.0 (F)" },
            new TestParameter { Id = 3, TestTypeId = 1, Name = "Hemoglobin", Unit = "g/dL", ReferenceRange = "13.5-17.5 (M), 12.0-15.5 (F)" },
            new TestParameter { Id = 4, TestTypeId = 1, Name = "Hematocrit", Unit = "%", ReferenceRange = "41-53 (M), 36-46 (F)" },
            new TestParameter { Id = 5, TestTypeId = 1, Name = "MCV", Unit = "fL", ReferenceRange = "80-100" },
            new TestParameter { Id = 6, TestTypeId = 1, Name = "MCH", Unit = "pg", ReferenceRange = "27-33" },
            new TestParameter { Id = 7, TestTypeId = 1, Name = "MCHC", Unit = "g/dL", ReferenceRange = "32-36" },
            new TestParameter { Id = 8, TestTypeId = 1, Name = "Platelets", Unit = "10³/µL", ReferenceRange = "150-400" },
            // Lipid Profile
            new TestParameter { Id = 9, TestTypeId = 2, Name = "Total Cholesterol", Unit = "mg/dL", ReferenceRange = "<200" },
            new TestParameter { Id = 10, TestTypeId = 2, Name = "HDL Cholesterol", Unit = "mg/dL", ReferenceRange = ">40 (M), >50 (F)" },
            new TestParameter { Id = 11, TestTypeId = 2, Name = "LDL Cholesterol", Unit = "mg/dL", ReferenceRange = "<100" },
            new TestParameter { Id = 12, TestTypeId = 2, Name = "Triglycerides", Unit = "mg/dL", ReferenceRange = "<150" },
            new TestParameter { Id = 13, TestTypeId = 2, Name = "VLDL", Unit = "mg/dL", ReferenceRange = "2-30" },
            // LFT
            new TestParameter { Id = 14, TestTypeId = 3, Name = "Total Bilirubin", Unit = "mg/dL", ReferenceRange = "0.2-1.2" },
            new TestParameter { Id = 15, TestTypeId = 3, Name = "Direct Bilirubin", Unit = "mg/dL", ReferenceRange = "0.0-0.3" },
            new TestParameter { Id = 16, TestTypeId = 3, Name = "ALT (SGPT)", Unit = "U/L", ReferenceRange = "7-56" },
            new TestParameter { Id = 17, TestTypeId = 3, Name = "AST (SGOT)", Unit = "U/L", ReferenceRange = "10-40" },
            new TestParameter { Id = 18, TestTypeId = 3, Name = "Alkaline Phosphatase", Unit = "U/L", ReferenceRange = "44-147" },
            new TestParameter { Id = 19, TestTypeId = 3, Name = "Total Protein", Unit = "g/dL", ReferenceRange = "6.3-8.2" },
            new TestParameter { Id = 20, TestTypeId = 3, Name = "Albumin", Unit = "g/dL", ReferenceRange = "3.5-5.0" },
            // KFT
            new TestParameter { Id = 21, TestTypeId = 4, Name = "Blood Urea Nitrogen (BUN)", Unit = "mg/dL", ReferenceRange = "7-20" },
            new TestParameter { Id = 22, TestTypeId = 4, Name = "Creatinine", Unit = "mg/dL", ReferenceRange = "0.7-1.3 (M), 0.6-1.1 (F)" },
            new TestParameter { Id = 23, TestTypeId = 4, Name = "Uric Acid", Unit = "mg/dL", ReferenceRange = "3.4-7.0 (M), 2.4-6.0 (F)" },
            new TestParameter { Id = 24, TestTypeId = 4, Name = "Sodium", Unit = "mEq/L", ReferenceRange = "136-145" },
            new TestParameter { Id = 25, TestTypeId = 4, Name = "Potassium", Unit = "mEq/L", ReferenceRange = "3.5-5.0" },
            new TestParameter { Id = 26, TestTypeId = 4, Name = "Chloride", Unit = "mEq/L", ReferenceRange = "98-107" },
            // Urine Analysis
            new TestParameter { Id = 27, TestTypeId = 5, Name = "Color", Unit = "", ReferenceRange = "Pale Yellow" },
            new TestParameter { Id = 28, TestTypeId = 5, Name = "Appearance", Unit = "", ReferenceRange = "Clear" },
            new TestParameter { Id = 29, TestTypeId = 5, Name = "pH", Unit = "", ReferenceRange = "4.6-8.0" },
            new TestParameter { Id = 30, TestTypeId = 5, Name = "Specific Gravity", Unit = "", ReferenceRange = "1.005-1.030" },
            new TestParameter { Id = 31, TestTypeId = 5, Name = "Protein", Unit = "", ReferenceRange = "Negative" },
            new TestParameter { Id = 32, TestTypeId = 5, Name = "Glucose", Unit = "", ReferenceRange = "Negative" },
            new TestParameter { Id = 33, TestTypeId = 5, Name = "Ketones", Unit = "", ReferenceRange = "Negative" },
            new TestParameter { Id = 34, TestTypeId = 5, Name = "Blood", Unit = "", ReferenceRange = "Negative" }
        );
    }
}
