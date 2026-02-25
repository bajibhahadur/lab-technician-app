using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabTechnicianApp.Data;
using LabTechnicianApp.Models;

namespace LabTechnicianApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestResultsController : ControllerBase {
    private readonly AppDbContext _db;
    public TestResultsController(AppDbContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _db.TestResults
            .Include(r => r.Patient)
            .Include(r => r.TestType)
            .Include(r => r.Items).ThenInclude(i => i.TestParameter)
            .OrderByDescending(r => r.TestDate)
            .ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) {
        var result = await _db.TestResults
            .Include(r => r.Patient)
            .Include(r => r.TestType)
            .Include(r => r.Items).ThenInclude(i => i.TestParameter)
            .FirstOrDefaultAsync(r => r.Id == id);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpGet("patient/{patientId}")]
    public async Task<IActionResult> GetByPatient(int patientId) =>
        Ok(await _db.TestResults
            .Include(r => r.Patient)
            .Include(r => r.TestType)
            .Include(r => r.Items).ThenInclude(i => i.TestParameter)
            .Where(r => r.PatientId == patientId)
            .OrderByDescending(r => r.TestDate)
            .ToListAsync());

    [HttpPost]
    public async Task<IActionResult> Create(TestResult testResult) {
        testResult.TestDate = DateTime.Now;
        _db.TestResults.Add(testResult);
        await _db.SaveChangesAsync();
        var saved = await _db.TestResults
            .Include(r => r.Patient)
            .Include(r => r.TestType)
            .Include(r => r.Items).ThenInclude(i => i.TestParameter)
            .FirstOrDefaultAsync(r => r.Id == testResult.Id);
        return CreatedAtAction(nameof(Get), new { id = testResult.Id }, saved);
    }
}
