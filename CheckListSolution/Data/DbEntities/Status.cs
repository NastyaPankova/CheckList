using System.ComponentModel.DataAnnotations;

namespace DbEntities;
public class Status : BaseEntity

{
    [Required]
    [Key]
    public string Name { get; set; }
    public virtual ICollection<ListItem> ListItems { get; set; }

}
