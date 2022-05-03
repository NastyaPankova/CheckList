namespace DbEntities;

public class CheckList : BaseEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTime DateTime { get; set; }
    public virtual ICollection<CheckListUser> CheckListUsers { get; set; }
    public virtual ICollection<ListItem> ListItems { get; set; }
}
