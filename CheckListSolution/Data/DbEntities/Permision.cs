namespace DbEntities;

public class Permision : BaseEntity

{
    public string Name { get; set; }
    public virtual ICollection<CheckListUser> CheckListUsers { get; set; }
}
