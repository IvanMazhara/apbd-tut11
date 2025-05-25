using apbd_11.Data;
using apbd_11.Models;

namespace apbd_11.Repositories;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<List<Prescription>> GetAllPrescriptions()
    {
        throw new NotImplementedException();
    }

    public async Task<Patient> GetPatient(int Id)
    {
        var patient = await _context.Patients.Select(e => { });
        throw new NotImplementedException();
    }

    public Task<Prescription> addPrescription(Prescription prescription)
    {
        throw new NotImplementedException();
    }
}