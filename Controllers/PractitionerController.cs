using MedicoAPI.Services;
using MedicoAPI.Services.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MedicoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PractitionerController: ControllerBase
{
    private IPractitionerService _practitionerService;

    public PractitionerController(IPractitionerService practitionerService)
    {
        _practitionerService = practitionerService;
    }

    [HttpGet]
    public ActionResult<List<PractitionerResponseDto>> GetPractitioners()
    {
        return Ok(_practitionerService.GetPractitioners());
    }

    [HttpGet("{id}")]
    public ActionResult<PractitionerResponseDto> GetPractitionerById(int id)
    {
        return Ok(_practitionerService.GetPractitionerById(id));
    }

    [HttpPost]
    public IActionResult CreatePractitioner(PractitionerCreateDto patientCreateDto)
    {
        PractitionerResponseDto practitioner = _practitionerService.CreatePractitioner(patientCreateDto);
        return Created($"api/practitioner/{practitioner.Id}", practitioner);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePractitioner(PractitionerUpdateDto patientUpdateDto)
    {
        return Ok(_practitionerService.UpdatePractitioner(patientUpdateDto));
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePractitioner(int id)
    {
        _practitionerService.DeletePractitioner(id);
        return NoContent();
    }
}