using MedicoAPI.Models;

namespace MedicoAPI.Repositories;

public interface IAppointmentRepository
{
    List<Appointment> GetAppointments();
    Appointment? GetAppointmentById(int id);
    Appointment CreateAppointment(Appointment appointment);
    Appointment? UpdateAppointment(Appointment appointment);
    void DeleteAppointment(int id);
}