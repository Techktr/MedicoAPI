using MedicoAPI.Models;
using MedicoAPI.Services.DTOs;

namespace MedicoAPI.Services.Mappers;

public class PractitionerMapper
{
    public PractitionerResponseDto EntityToResponseDto(Practitioner entity)
    {
        return new PractitionerResponseDto
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Speciality = entity.Speciality,
            Address = entity.Address,
        };
    }

    public List<PractitionerResponseDto> EntityToResponseDtos(List<Practitioner> entities)
    {
        return entities.Select(entity => EntityToResponseDto(entity)).ToList();
    }

    public Practitioner EntityToCreateDto(PractitionerCreateDto dto)
    {
        return new Practitioner()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Speciality = dto.Speciality,
            Address = dto.Address,
        };
    }

    public Practitioner EntityToUpdateDto(PractitionerUpdateDto dto)
    {
        return new Practitioner()
        {
            Id = dto.Id,
            Speciality = dto.Speciality,
            Address = dto.Address,
        };
    }

}