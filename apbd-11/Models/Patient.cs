using System.ComponentModel.DataAnnotations;

namespace apbd_11.Models;

public class Patient
{
    [Key] public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
}