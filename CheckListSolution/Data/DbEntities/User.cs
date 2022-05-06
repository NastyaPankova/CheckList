using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DbEntities;
[Index("Uid", IsUnique = true)]
public class User : IdentityUser<Guid>
{
    [Required]
    public virtual Guid Uid { get; set; } = Guid.NewGuid();
    [Required]
    public string Name { get; set; }
    public virtual ICollection<CheckListUser> CheckListUsers { get; set; }
}
