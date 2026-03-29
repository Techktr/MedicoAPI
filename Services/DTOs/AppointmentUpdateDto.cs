namespace MedicoAPI.Services.DTOs;

public class AppointmentUpdateDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int PatientId { get; set; }
    public int PractitionerId { get; set; }
}