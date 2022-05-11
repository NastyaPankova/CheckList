namespace CheckListService;

public interface IStateService
{
    Task AddPermision(string Name);
    Task UpdatePermision(int PermisionId, string NewName);
    Task DeletePermision(string Name);
    Task AddStatus(string Name);
    Task UpdateStatus(int StatusId, string NewName);
    Task DeleteStatus(string Name);


}