using MedicoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicoAPI.Data;

public class MedicoDbContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }

    public MedicoDbContext(DbContextOptions<MedicoDbContext> options) : base(options)
    {

    }
}