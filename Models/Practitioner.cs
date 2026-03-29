namespace MedicoAPI.Models;

public class Practitioner
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Speciality { get; set; }
    public string Address { get; set; }
}