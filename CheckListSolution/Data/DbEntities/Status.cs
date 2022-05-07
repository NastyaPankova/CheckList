using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbEntities;
public class Status : BaseEntity

{
    [Required]
    public string Name { get; set; }
    public virtual ICollection<ListItem> ListItems { get; set; }

}
