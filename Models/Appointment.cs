namespace MedicoAPI.Models;

public class Appointment
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
    public int PractitionerId { get; set; }
    public Practitioner Practitioner { get; set; }
}