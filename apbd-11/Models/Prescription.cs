using System.ComponentModel.DataAnnotations;

namespace apbd_11.Models;

public class Prescription
{
    [Key] public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
}