using apbd_11.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd_11.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>().ToTable("Patient");
        modelBuilder.Entity<Doctor>().ToTable("Doctor");
        modelBuilder.Entity<Medicament>().ToTable("Medicament");
        modelBuilder.Entity<Prescription>().ToTable("Prescription");
        modelBuilder.Entity<PrescriptionMedicament>().ToTable("PrescriptionMedicament");

        modelBuilder.Entity<Doctor>().HasData(new Doctor
        {
            IdDoctor = 1,
            FirstName = "Vic",
            LastName = "Morrow",
            Email = "vicmor1967@gmail.com"
        });

        modelBuilder.Entity<Patient>().HasData(
            new Patient
            {
                IdPatient = 1,
                FirstName = "John",
                LastName = "Doe",
                Birthdate = new DateTime(1966, 03, 01)
            },
            new Patient
            {
                IdPatient = 2,
                FirstName = "Alice",
                LastName = "Smith",
                Birthdate = new DateTime(1985, 3, 10)
            },
            new Patient
            {
                IdPatient = 3,
                FirstName = "Bob",
                LastName = "Johnson",
                Birthdate = new DateTime(1990, 8, 22)
            },
            new Patient
            {
                IdPatient = 4,
                FirstName = "Llewelyn",
                LastName = "Moss",
                Birthdate = new DateTime(1978, 12, 5)
            },
            new Patient
            {
                IdPatient = 5,
                FirstName = "Monica",
                LastName = "Lee",
                Birthdate = new DateTime(2000, 6, 14)
            }
        );

        
        modelBuilder.Entity<Medicament>().HasData(new Medicament
        {
            IdMedicament = 1,
            Name = "Ibuprofen",
            Description = "Take pill once a day.",
            Type = "Nonsteroidal anti-inflammatory drug (NSAID)"
        });
    }
}