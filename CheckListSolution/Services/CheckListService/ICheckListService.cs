using CheckListService.Models;
namespace CheckListService;

public interface ICheckListService
{
    Task<CheckListModel> AddCheckList(AddCheckListModel model);
}
