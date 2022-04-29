namespace CheckListService;

public interface ICheckListService
{
    Task<CheckListModel> AddChecklist(AddChecklistModel model);
    Task<IEnumerable<CheckListModel>> GetCheckLists();
}
