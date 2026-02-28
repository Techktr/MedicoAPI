using MedicoAPI.Services;
using MedicoAPI.Services.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MedicoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController: ControllerBase
{
    private IPatientService _patientService;

    public  PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet]
    public ActionResult<List<PatientResponseDto>> GetPatients()
    {
        return Ok(_patientService.GetPatients());
    }

    [HttpGet("{id}")]
    public IActionResult GetPatientById(int id)
    {
        return Ok(_patientService.GetPatientById(id));
    }

    [HttpPost]
    public IActionResult CreatePatient(PatientCreateDto patientCreateDto)
    {
        PatientResponseDto patient = _patientService.CreatePatient(patientCreateDto);
        return Created($"api/patient/{patient.Id}", patient);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePatient(int id, PatientUpdateDto patientUpdateDto)
    {
        return Ok(_patientService.UpdatePatient(patientUpdateDto));
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePatient(int id)
    {
        _patientService.DeletePatient(id);
        return NoContent();
    }

}