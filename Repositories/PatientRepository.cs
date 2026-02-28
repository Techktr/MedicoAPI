using MedicoAPI.Data;
using MedicoAPI.Models;
using MedicoAPI.Services.DTOs;

namespace MedicoAPI.Repositories;

public class PatientRepository : IPatientRepository
{
    private MedicoDbContext _context;

    public PatientRepository(MedicoDbContext context)
    {
        _context = context;
    }

    public List<Patient> GetPatients()
    {
        return _context.Patients.ToList();
    }

    public Patient? GetPatientById(int id)
    {
        return _context.Patients.Find(id);
    }

    public Patient CreatePatient(Patient patient)
    {
        _context.Patients.Add(patient);
        _context.SaveChanges();
        return patient;
    }

    public Patient? UpdatePatient(PatientUpdateDto patient)
    {
        Patient? patientToUpdate = _context.Patients.Find(patient.Id);
        if (patientToUpdate == null)
        {
            throw new Exception("Patient does not exist");
        }

        patientToUpdate.Address = patient.Address;
        patientToUpdate.Age = patient.Age;
        patientToUpdate.SportName = patient.SportName;
        _context.Patients.Update(patientToUpdate);
        _context.SaveChanges();
        return patientToUpdate;
    }

    public void DeletePatient(int id)
    {
        Patient? patientToDelete = _context.Patients.Find(id);
        if (patientToDelete == null)
        {
            throw new Exception("Patient does not exist");
        }
        _context.Patients.Remove(patientToDelete);
        _context.SaveChanges();
    }

}