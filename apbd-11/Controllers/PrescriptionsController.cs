using apbd_11.DTOs;
using apbd_11.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace apbd_11.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrescriptionsController : ControllerBase
{
    private readonly IDbService _dbService;

    public PrescriptionsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    public async Task<IActionResult> AddPrescription([FromBody] PrescriptionDto request)
    {
        try
        {
            var success = await _dbService.AddPrescription(request);
            return success ? Ok("Prescription added successfully.") : BadRequest("Failed to add prescription.");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }
}