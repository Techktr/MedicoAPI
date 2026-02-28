using MedicoAPI.Models;
using MedicoAPI.Services.DTOs;

namespace MedicoAPI.Services.Mappers;

public class PatientMapper
{

    public PatientResponseDto EntityToResponseDto(Patient patient)
    {
        return new PatientResponseDto
        {

            Id = patient.Id,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            Age = patient.Age,
            Address = patient.Address,
            SportName = patient.SportName
        };
    }

    public List<PatientResponseDto> EntityToResponseDtos(List<Patient> patients)
    {
        return patients.Select(patient => EntityToResponseDto(patient)).ToList();
    }

    public Patient ResponseDtoToEntity(PatientResponseDto dto)
    {
        return new Patient()
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Age = dto.Age,
            Address = dto.Address,
            SportName = dto.SportName
        };
    }

    public Patient CreateDtoToEntity(PatientCreateDto dto)
    {
        return new Patient()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Age = dto.Age,
            Address = dto.Address,
            SportName = dto.SportName
        };
    }

    public Patient UpdateDtoToEntity(PatientUpdateDto dto)
    {
        return new Patient()
        {
            Id = dto.Id,
            Address = dto.Address,
            Age = dto.Age,
            SportName = dto.SportName
        };
    }

    public Patient DeleteDtoToEntity(PatientDeleteDto dto)
    {
        return new Patient(){Id = dto.Id};
    }

}