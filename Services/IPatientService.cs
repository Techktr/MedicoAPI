using MedicoAPI.Services.DTOs;

namespace MedicoAPI.Services;

public interface IPatientService
{
    List<PatientResponseDto> GetPatients();
    PatientResponseDto GetPatientById(int id);
    PatientResponseDto CreatePatient(PatientCreateDto patientCreateDto);
    PatientResponseDto UpdatePatient(PatientUpdateDto patientUpdateDto);
    void DeletePatient(PatientDeleteDto patientDeleteDto);
}