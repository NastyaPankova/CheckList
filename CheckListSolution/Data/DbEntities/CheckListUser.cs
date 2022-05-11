using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbEntities;
[Table("CheckList_User")]
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