using MedicoAPI.Data;
using MedicoAPI.Models;

namespace MedicoAPI.Repositories;

public class PractitionerRepository: IPractitionerRepository
{
    private MedicoDbContext _context;

    public PractitionerRepository(MedicoDbContext context)
    {
        _context = context;
    }

    public List<Practitioner> GetPractitioners()
    {
        return _context.Practitioners.ToList();
    }

    public Practitioner? GetPractitionerById(int id)
    {
       return _context.Practitioners.Find(id);
    }

    public Practitioner createPractitioner(Practitioner practitioner)
    {
        _context.Practitioners.Add(practitioner);
        _context.SaveChanges();
        return practitioner;
    }

    public Practitioner? updatePractitioner(Practitioner practitioner)
    {
        Practitioner? practitionerToUpdate = _context.Practitioners.Find(practitioner.Id);
        if (practitionerToUpdate == null)
        {
            throw new Exception("Practitioner not exists");
        }
        practitionerToUpdate.Address = practitioner.Address;
        practitionerToUpdate.Speciality = practitioner.Speciality;
        _context.Practitioners.Update(practitionerToUpdate);
        _context.SaveChanges();
        return practitionerToUpdate;
    }

    public void DeletePractitioner(int id)
    {
        Practitioner? practitionerToDelete = _context.Practitioners.Find(id);
        if (practitionerToDelete == null)
        {
            throw new Exception("Practitioner not exists");
        }
        _context.Practitioners.Remove(practitionerToDelete);
        _context.SaveChanges();
    }
}