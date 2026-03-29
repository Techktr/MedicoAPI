namespace MedicoAPI.Services.DTOs;

public class AppointmentCreateDto
{
    public DateTime Date { get; set; }
    public int PatientId { get; set; }
    public int PractitionerId { get; set; }
}