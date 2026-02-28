namespace MedicoAPI.Services.DTOs;

public class PatientCreateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public int Age { get; set; }
    public string SportName { get; set; }
}