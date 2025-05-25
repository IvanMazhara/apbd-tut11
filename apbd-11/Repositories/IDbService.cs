using apbd_11.DTOs;
using apbd_11.Models;

namespace apbd_11.Repositories;

public interface IDbService
{
    Task<Patient?> GetPatientDetails(int id);
    Task<bool> AddPrescription(PrescriptionDto prescriptionDto);
}