using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbEntities;
public class Permision : BaseEntity

{
    [Required]
    public string Name { get; set; }
    public virtual ICollection<CheckListUser> CheckListUsers { get; set; }
}
