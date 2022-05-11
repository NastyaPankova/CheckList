namespace CheckListService.Models;
public class ListItemModel
{
    public int? Id { get; set; }
    public string? Content { get; set; }
    public DateTime? Date { get; set; }
    public decimal? Cost { get; set; }
    public string? Status { get; set; }
}