using MedicoAPI.Models;
using MedicoAPI.Services.DTOs;

namespace MedicoAPI.Services.Mappers;

public class AppointmentMapper
{
    public AppointmentResponseDto EntityToResponseDto(Appointment entity)
    {
        return new AppointmentResponseDto()
        {
            Id = entity.Id,
            Date = entity.Date,
            PatientId = entity.PatientId,
            PatientFullName = entity.Patient.LastName + " " + entity.Patient.FirstName,
            PractitionerId = entity.PractitionerId,
            PractitionerFullName =  entity.Practitioner.LastName + " " + entity.Practitioner.FirstName,
        };
    }

    public List<AppointmentResponseDto> EntityToResponseDtos(List<Appointment> entities){
        return entities.Select(entity => EntityToResponseDto(entity)).ToList();
    }

    public Appointment EntityToCreateDto(AppointmentCreateDto dto)
    {
        return new Appointment()
        {
            Date = dto.Date,
            PatientId = dto.PatientId,
            PractitionerId = dto.PractitionerId,
        };
    }

    public Appointment EntityToUpdateDto(AppointmentUpdateDto dto)
    {
        return new Appointment()
        {
            Id = dto.Id,
            Date = dto.Date,
            PatientId = dto.PatientId,
            PractitionerId = dto.PractitionerId
        };
    }
}