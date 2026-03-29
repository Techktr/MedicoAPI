using MedicoAPI.Services.DTOs;

namespace MedicoAPI.Services;

public interface IAppointmentService
{
    List<AppointmentResponseDto> GetAppointments();
    AppointmentResponseDto GetAppointmentById(int id);
    AppointmentResponseDto CreateAppointment(AppointmentCreateDto patientCreateDto);
    AppointmentResponseDto UpdateAppointment(AppointmentUpdateDto patientUpdateDto);
    void DeleteAppointment(int id);
}