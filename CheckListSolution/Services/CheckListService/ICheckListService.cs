using CheckListService.Models;
using Common;

namespace CheckListService;

public interface ICheckListService
{
    Task<IEnumerable<CheckListModel>> GetCheckLists(Guid UserId, 
                                                    int offset = CommonConstants.Offset, 
                                                    int limit = CommonConstants.LimitCheckLists);
    /*Task<CheckListModel> GetCheckList(Guid UserId, int CheckListId);
    Task<CheckListModel> AddCheckList(Guid UserId, AddCheckListModel model);
    Task ShareCheckList(Guid UserId, ShareCheckListModel model);
    Task UpdateCheckList(Guid UserId, UpdateCheckListModel model);
    Task DeleteCheckList(Guid UserId, int Id);*/
}