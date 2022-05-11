using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbEntities;
[Table("Permisions")]
public class Permision : BaseEntity

{
    [Required]
    public string Name { get; set; }
    public virtual ICollection<CheckListUser> CheckListUsers { get; set; }
}
