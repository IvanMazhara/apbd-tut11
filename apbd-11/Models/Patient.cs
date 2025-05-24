using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apbd_11.Models;

[Table("Patient")]
public class Patient
{
    [Key] public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
}