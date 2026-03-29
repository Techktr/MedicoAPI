using MedicoAPI.Models;
using MedicoAPI.Services;
using MedicoAPI.Services.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MedicoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentController: ControllerBase
{
    private IAppointmentService _service;

    public AppointmentController(IAppointmentService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<AppointmentResponseDto>> GetAppointments()
    {
        return Ok(_service.GetAppointments());
    }

    [HttpGet("{id}")]
    public ActionResult<AppointmentResponseDto> GetAppointmentById(int id)
    {
        return Ok(_service.GetAppointmentById(id));
    }

    [HttpPost]
    public ActionResult<AppointmentResponseDto> CreateAppointment(AppointmentCreateDto appointmentCreateDto)
    {
        AppointmentResponseDto appointmentResponseDto =  _service.CreateAppointment(appointmentCreateDto);
        return Created($"api/patient/{appointmentResponseDto.Id}", appointmentResponseDto);
    }

    [HttpPut("{id}")]
    public ActionResult<AppointmentResponseDto> UpdateAppointment(AppointmentUpdateDto appointmentUpdateDto)
    {
        return Ok(_service.UpdateAppointment(appointmentUpdateDto));
    }

    [HttpDelete("{id}")]
    public ActionResult<AppointmentResponseDto> DeleteAppointment(int id)
    {
        _service.DeleteAppointment(id);
        return NoContent();
    }
}