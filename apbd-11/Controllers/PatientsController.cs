using apbd_11.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace apbd_11.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly IDbService _dbService;

    public PatientsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatientDetails(int id)
    {
        var patient = await _dbService.GetPatientDetails(id);
        if (patient == null)
            return NotFound($"Patient with ID {id} not found.");

        return Ok(patient);
    }
}