using System.ComponentModel.DataAnnotations;

namespace DbEntities;
public class CheckListUser
{
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public int CheckListId { get; set; }
    [Required]
    public User User { get; set; }
    public CheckList CheckList { get; set; }
    public Permision Permision { get; set; }
}