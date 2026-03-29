using MedicoAPI.Models;

namespace MedicoAPI.Repositories;

public interface IPractitionerRepository
{
    List<Practitioner> GetPractitioners();

    Practitioner? GetPractitionerById(int id);

    Practitioner createPractitioner(Practitioner practitioner);

    Practitioner? updatePractitioner(Practitioner practitioner);

    void DeletePractitioner(int id);
}