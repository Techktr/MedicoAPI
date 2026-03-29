using MedicoAPI.Models;
using Microsoft.EntityFrameworkCore;
using MedicoAPI.Data;

namespace MedicoAPI.Repositories;

public class AppointmentRepository: IAppointmentRepository
{

    private MedicoDbContext _context;

    public AppointmentRepository(MedicoDbContext context)
    {
        _context = context;
    }

    public List<Appointment> GetAppointments()
    {
        return _context.Appointments.Include(appointment => appointment.Patient)
            .Include(appointment => appointment.Practitioner).ToList();
    }

    public Appointment? GetAppointmentById(int id)
    {
        return _context.Appointments.Include(appointment => appointment.Patient)
            .Include(appointment => appointment.Practitioner)
            .FirstOrDefault(appointment => appointment.Id == id);
    }

    public Appointment CreateAppointment(Appointment appointment)
    {
        _context.Appointments.Add(appointment);
        _context.SaveChanges();
        return appointment;
    }

    public Appointment? UpdateAppointment(Appointment appointment)
    {
        Appointment? appointmentToUpdate = _context.Appointments.Find(appointment.Id);
        if (appointmentToUpdate == null)
        {
            throw new Exception("Appointment does not exist");
        }

        appointmentToUpdate.Date = appointment.Date;
        appointmentToUpdate.PatientId = appointment.PatientId;
        appointmentToUpdate.PractitionerId = appointment.PractitionerId;
        _context.Appointments.Update(appointmentToUpdate);
        _context.SaveChanges();
        return appointmentToUpdate;
    }

    public void DeleteAppointment(int id)
    {
        Appointment? appointmentToDelete = _context.Appointments.Find(id);
        if (appointmentToDelete == null)
        {
            throw new Exception("Appointment does not exist");
        }
        _context.Appointments.Remove(appointmentToDelete);
        _context.SaveChanges();
    }
}