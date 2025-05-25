namespace apbd_11.DTOs;

public class PrescriptionDto
{
    public int IdDoctor { get; set; }
    public int IdPatient { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public List<MedicamentDto> Medicaments { get; set; } = new();
    public PatientDto? Patient { get; set; }
}

public class MedicamentDto
{
    public int IdMedicament { get; set; }
    public int? Dose { get; set; }
    public string Description { get; set; } = string.Empty;
}

public class DoctorDto
{
    public int IdDoctor { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

