namespace DbEntities;

public class Status : BaseEntity

{
    public string Name { get; set; }
    public virtual ICollection<ListItem> ListItems { get; set; }

}
