using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLiteDbAccess.Data.Models;

[Table(nameof(User))]
public class User
{
    [Key]
    public int UserID { get; set; }

    [Required]
    public string? FirstName { get; set; }

    [Required]
    public string? LastName { get; set; }

    public string? Email { get; set; }
}
