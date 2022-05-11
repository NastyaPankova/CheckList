using CheckListService.Models;

namespace CheckListService;

public interface ICheckListService
{
    Task<IEnumerable<CheckListModel>> GetCheckLists(Guid UserId);
    Task<CheckListByIdModel> GetCheckListById(Guid UserId, int CheckListId);
    Task AddCheckList(Guid UserId, AddCheckListModel model);
    /*Task ShareCheckList(Guid UserId, ShareCheckListModel model);
    Task UpdateCheckList(Guid UserId, UpdateCheckListModel model);
    Task DeleteCheckList(Guid UserId, int Id);*/
}