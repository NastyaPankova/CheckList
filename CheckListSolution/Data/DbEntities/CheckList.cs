using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common;

namespace DbEntities;
[Table("CheckLists")]
public class CheckList : BaseEntity
{
    [Required]
    [MaxLength(CommonConstants.MaxNameListLength)]
    public string Name { get; set; }

    [MaxLength(CommonConstants.MaxDescriptionListLength)]
    public string? Description { get; set; }

    [Required]
    public DateTime Date { get; set; }
    public virtual ICollection<CheckListUser> CheckListUsers { get; set; }
    public virtual ICollection<ListItem> ListItems { get; set; }
}
