using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabTechnicianApp.Data;

namespace LabTechnicianApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestTypesController : ControllerBase {
    private readonly AppDbContext _db;
    public TestTypesController(AppDbContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _db.TestTypes.Include(t => t.Parameters).ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) {
        var testType = await _db.TestTypes.Include(t => t.Parameters).FirstOrDefaultAsync(t => t.Id == id);
        return testType == null ? NotFound() : Ok(testType);
    }
}
