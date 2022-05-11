using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbEntities;
[Table("Users")]
public class User : IdentityUser<Guid>
{
    [Required]
    public string Name { get; set; }
    public virtual ICollection<CheckListUser> CheckListUsers { get; set; }
}
