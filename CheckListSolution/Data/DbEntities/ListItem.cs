using Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbEntities;
[Table("ListItems")]
public class ListItem : BaseEntity
{
    [Required]
    [MaxLength(CommonConstants.MaxContentItemLength)]
    public string Content { get; set; }
    public DateTime? Date { get; set; }

    [Column(TypeName = "money")]
    public decimal? Cost { get; set; }
    public CheckList CheckList { get; set; }
    public Status Status { get; set; }
}
