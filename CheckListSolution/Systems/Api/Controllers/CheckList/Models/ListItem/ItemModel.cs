namespace Api.Controllers.CheckList.Models;
public class ItemModel
{
    public int? Id { get; set; }
    public string? Content { get; set; }
    public DateTime? Date { get; set; }
    public decimal? Cost { get; set; }
    public string? Status { get; set; }
    public int? CheckListId { get; set; }

}