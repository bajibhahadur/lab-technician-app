using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabTechnicianApp.Data;
using LabTechnicianApp.Models;

namespace LabTechnicianApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase {
    private readonly AppDbContext _db;
    public PatientsController(AppDbContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _db.Patients.OrderByDescending(p => p.Date).ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) {
        var patient = await _db.Patients.FindAsync(id);
        return patient == null ? NotFound() : Ok(patient);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Patient patient) {
        patient.Date = DateTime.Now;
        _db.Patients.Add(patient);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = patient.Id }, patient);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Patient patient) {
        if (id != patient.Id) return BadRequest();
        _db.Entry(patient).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) {
        var patient = await _db.Patients.FindAsync(id);
        if (patient == null) return NotFound();
        _db.Patients.Remove(patient);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
