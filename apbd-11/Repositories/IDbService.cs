using apbd_11.Models;

namespace apbd_11.Repositories;

public interface IDbService
{
    Task<List<Prescription>> GetAllPrescriptions();
    Task<Patient> GetPatient(int Id);
    Task<Prescription> addPrescription(Prescription prescription);
    
}