using MedicoAPI.Models;

namespace MedicoAPI.Services.DTOs;

public class AppointmentResponseDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int PatientId { get; set; }
    public string PatientFullName { get; set; }
    public int PractitionerId { get; set; }
    public string PractitionerFullName { get; set; }
}