using CheckListService.Models;

namespace CheckListService;

public interface IListItemService
{
    Task AddItem(AddItemModel model);
    Task MarkItem(int ListItemId);
    Task UpdateItem(UpdateItemModel model);
    Task DeleteItem(int ListItemId);
}