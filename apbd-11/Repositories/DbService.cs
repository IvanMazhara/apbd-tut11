using apbd_11.Data;
using apbd_11.DTOs;
using apbd_11.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd_11.Repositories;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Patient?> GetPatientDetails(int id)
    {
        var patient = await _context.Patients
            .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.Doctor)
            .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.PrescriptionMedicaments)
            .ThenInclude(pm => pm.Medicament)
            .FirstOrDefaultAsync(p => p.IdPatient == id);

        if (patient == null)
            return null;
        
        patient.Prescriptions = patient.Prescriptions.OrderBy(p => p.DueDate).ToList();

        return patient;
    }

    public async Task<bool> AddPrescription(PrescriptionDto prescriptionDto)
    {
        if (prescriptionDto.DueDate < prescriptionDto.Date)
            throw new ArgumentException("DueDate must be greater than or equal to Date.");

        if (prescriptionDto.Medicaments.Count > 10)
            throw new ArgumentException("Cannot assign more than 10 medicaments.");

        var doctor = await _context.Doctors.FindAsync(prescriptionDto.IdDoctor);
        if (doctor == null)
            throw new ArgumentException("Doctor does not exist.");

        var patient = await _context.Patients.FindAsync(prescriptionDto.IdPatient);
        if (patient == null)
        {
            if (prescriptionDto.Patient == null)
                throw new ArgumentException("Patient does not exist and no data provided to create one.");

            patient = new Patient
            {
                FirstName = prescriptionDto.Patient.FirstName,
                LastName = prescriptionDto.Patient.LastName,
                Birthdate = prescriptionDto.Patient.Birthdate
            };
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        var prescription = new Prescription
        {
            Date = prescriptionDto.Date,
            DueDate = prescriptionDto.DueDate,
            IdDoctor = doctor.IdDoctor,
            IdPatient = patient.IdPatient,
            PrescriptionMedicaments = new List<PrescriptionMedicament>()
        };

        foreach (var medDto in prescriptionDto.Medicaments)
        {
            var medicament = await _context.Medicaments.FindAsync(medDto.IdMedicament);
            if (medicament == null)
                throw new ArgumentException($"Medicament with ID {medDto.IdMedicament} does not exist.");

            prescription.PrescriptionMedicaments.Add(new PrescriptionMedicament
            {
                IdMedicament = medicament.IdMedicament,
                Dose = medDto.Dose,
                Details = medDto.Description
            });
        }

        _context.Prescriptions.Add(prescription);
        await _context.SaveChangesAsync();
        return true;
    }
}
