namespace DbEntities;

using Microsoft.AspNetCore.Identity;

public class User : IdentityUser<Guid>
{
    public string Name { get; set; }
    public virtual ICollection<CheckListUser> CheckListUsers { get; set; }
}
