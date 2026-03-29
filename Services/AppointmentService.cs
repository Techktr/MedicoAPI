using MedicoAPI.Models;
using MedicoAPI.Repositories;
using MedicoAPI.Services.DTOs;
using MedicoAPI.Services.Mappers;

namespace MedicoAPI.Services;

public class AppointmentService: IAppointmentService
{
    private IAppointmentRepository _repository;
    private AppointmentMapper _mapper;

    public AppointmentService(AppointmentMapper mapper, IAppointmentRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public List<AppointmentResponseDto> GetAppointments()
    {
        return _mapper.EntityToResponseDtos(_repository.GetAppointments());
    }

    public AppointmentResponseDto GetAppointmentById(int id)
    {
        Appointment? appointment = _repository.GetAppointmentById(id);
        if (appointment == null)
        {
            throw new Exception("Appointment not found");
        }
        return _mapper.EntityToResponseDto(appointment) ?? throw new Exception("Appointment not found");
    }

    public AppointmentResponseDto CreateAppointment(AppointmentCreateDto patientCreateDto)
    {
        Appointment appointment = _repository.CreateAppointment(_mapper.EntityToCreateDto(patientCreateDto));
        if (appointment == null)
        {
            throw new Exception("Appointment not created");
        }
        return _mapper.EntityToResponseDto(appointment);
    }

    public AppointmentResponseDto UpdateAppointment(AppointmentUpdateDto patientUpdateDto)
    {
        Appointment? appointment = _repository.UpdateAppointment(_mapper.EntityToUpdateDto(patientUpdateDto));
        if (appointment == null)
        {
            throw new Exception("Appointment not found");
        }
        return  _mapper.EntityToResponseDto(appointment) ?? throw new Exception("Appointment not found");
    }

    public void DeleteAppointment(int id)
    {
        _repository.DeleteAppointment(id);
    }
}