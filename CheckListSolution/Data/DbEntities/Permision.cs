using System.ComponentModel.DataAnnotations;

namespace DbEntities;
public class Permision : BaseEntity

{
    [Required]
    [Key]
    public string Name { get; set; }
    public virtual ICollection<CheckListUser> CheckListUsers { get; set; }
}
