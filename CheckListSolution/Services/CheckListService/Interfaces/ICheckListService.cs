using CheckListService.Models;

namespace CheckListService;

public interface ICheckListService
{
    Task<IEnumerable<CheckListModel>> GetCheckLists(Guid UserId);
    Task<CheckListByIdModel> GetCheckListById(Guid UserId, int CheckListId);
    Task AddCheckList(AddCheckListModel model);
    Task ShareCheckList(ShareCheckListModel model);
    Task UpdateCheckList(UpdateCheckListModel model);
    Task DeleteCheckList(Guid UserId, int CheckListId);
}