using MedicoAPI.Models;
using MedicoAPI.Services.DTOs;

namespace MedicoAPI.Repositories;

public interface IPatientRepository
{
    List<Patient> GetPatients();
    Patient? GetPatientById(int id);
    Patient CreatePatient(Patient patient);
    Patient? UpdatePatient(PatientUpdateDto patient);
    void DeletePatient(int id);
}