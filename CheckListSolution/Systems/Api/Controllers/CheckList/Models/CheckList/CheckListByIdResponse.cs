namespace Api.Controllers.CheckList.Models;
public class CheckListByIdResponse
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime? Date { get; set; }
    public string? Permision { get; set; }
    public string? Owner { get; set; }
    public List<ListItemResponse>? Items { get; set; }

}
