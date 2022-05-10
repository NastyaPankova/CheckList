using AutoMapper;
using CheckListService.Models;

namespace Api.Controllers.CheckList.Models;
public class GetCheckListResponse
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime? Date { get; set; }
    public string? Permision { get; set; }
}
