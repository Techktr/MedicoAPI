using MedicoAPI.Models;
using MedicoAPI.Repositories;
using MedicoAPI.Services.DTOs;
using MedicoAPI.Services.Mappers;

namespace MedicoAPI.Services;

public class PatientService: IPatientService
{

    private IPatientRepository _patientRepository;
    private PatientMapper _patientMapper;

    public PatientService(IPatientRepository patientRepository, PatientMapper patientMapper)
    {
        _patientRepository = patientRepository;
        _patientMapper = patientMapper;
    }

    public List<PatientResponseDto> GetPatients()
    {
        return _patientMapper.EntityToResponseDtos(_patientRepository.GetPatients());
    }

    public PatientResponseDto GetPatientById(int id)
    {
        Patient? patient = _patientRepository.GetPatientById(id);
        if (patient == null)
        {
            throw new Exception("Patient not found");
        }
        PatientResponseDto patientResponse = _patientMapper.EntityToResponseDto(patient);
        return patientResponse ?? throw new Exception("Patient not found");
    }

    public PatientResponseDto CreatePatient(PatientCreateDto patientCreateDto)
    {
        Patient patient = _patientRepository.CreatePatient(_patientMapper.CreateDtoToEntity(patientCreateDto));
        if (patient == null)
        {
            throw new Exception("Patient not found");
        }
        return _patientMapper.EntityToResponseDto(patient);
    }

    public PatientResponseDto UpdatePatient(PatientUpdateDto patientUpdateDto)
    {
        Patient? patient = _patientRepository.UpdatePatient(_patientMapper.UpdateDtoToEntity(patientUpdateDto));
        if (patient == null)
        {
            throw new Exception("Patient not found");
        }
        PatientResponseDto patientResponse = _patientMapper.EntityToResponseDto(patient);
        return patientResponse ?? throw new Exception("Patient not found");
    }

    public void DeletePatient(PatientDeleteDto patientDeleteDto)
    {
        _patientRepository.DeletePatient(_patientMapper.DeleteDtoToEntity(patientDeleteDto));
    }
}