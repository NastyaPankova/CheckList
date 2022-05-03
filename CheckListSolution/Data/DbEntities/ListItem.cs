namespace DbEntities;

using System.ComponentModel.DataAnnotations.Schema;

public class ListItem : BaseEntity
{
    public string Content { get; set; }
    public DateTime? DateTime { get; set; }

    [Column(TypeName = "money")]
    public decimal? Cost { get; set; }
    public CheckList CheckList { get; set; }
    public Status Status { get; set; }
}
