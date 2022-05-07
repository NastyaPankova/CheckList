using CheckListService.Models;
using Common;

namespace CheckListService;

public interface ICheckListService
{
    Task<IEnumerable<CheckListModel>> GetCheckLists(int offset = CommonConstants.Offset, int limit = CommonConstants.LimitCheckLists);
    Task<CheckListModel> GetCheckList(int id);
    Task<CheckListModel> AddCheckList(AddCheckListModel model);
    Task ShareCheckList(ShareCheckListModel model);
    Task UpdateCheckList(UpdateCheckListModel model);
    Task DeleteCheckList(int Id);
}