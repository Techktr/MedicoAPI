using MedicoAPI.Models;

namespace MedicoAPI.Repositories;

public interface IPatientRepository
{
    List<Patient> GetPatients();
    Patient? GetPatientById(int id);
    Patient CreatePatient(Patient patient);
    Patient? UpdatePatient(Patient patient);
    void DeletePatient(Patient patient);
}