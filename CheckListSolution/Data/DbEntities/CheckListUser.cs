namespace DbEntities;

using System;

public class CheckListUser
{
    public Guid UserId { get; set; }
    public int CheckListId { get; set; }
    public User User { get; set; }
    public CheckList CheckList { get; set; }
    public Permision Permision { get; set; }
}