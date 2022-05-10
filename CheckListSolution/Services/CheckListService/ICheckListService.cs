using CheckListService.Models;
using Common;

namespace CheckListService;

public interface ICheckListService
{
    Task<IEnumerable<GetCheckListModel>> GetCheckLists(Guid UserId);
    Task<GetCheckListByIdModel> GetCheckListById(Guid UserId, int CheckListId);
  /*  Task<CheckListModel> AddCheckList(Guid UserId, AddCheckListModel model);
    Task ShareCheckList(Guid UserId, ShareCheckListModel model);
    Task UpdateCheckList(Guid UserId, UpdateCheckListModel model);
    Task DeleteCheckList(Guid UserId, int Id);*/
}