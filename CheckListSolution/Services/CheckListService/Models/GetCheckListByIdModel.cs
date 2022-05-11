namespace CheckListService.Models;
public class GetCheckListByIdModel
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime? Date { get; set; }
    public string? Permision { get; set; }
    public string? Owner { get; set; }
    public List<ListItemModel>? Items { get; set; }

}