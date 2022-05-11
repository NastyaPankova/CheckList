using Api.Controllers.CheckList.Models;
using CheckListService.Models;

namespace Api.Controllers.CheckLists;

public static class CheckListControllerResponseMapper
{

    public static ListItemResponse ConvertToListItemResponse(this ListItemModel model)
    {
        var item = new ListItemResponse();
        item.Id = model.Id;
        item.Content = model.Content;
        item.Date = model.Date;
        item.Cost = model.Cost;
        item.Status = model.Status;

        return item;
    }
    public static GetCheckListByIdResponse ConvertToCheckListByIdResponse(this GetCheckListByIdModel model)
    {
        var items = model.Items.Select(d => d.ConvertToListItemResponse()).ToList();      

        var response = new GetCheckListByIdResponse();
        response.Id = model.Id;
        response.Name = model.Name;
        response.Description = model.Description;
        response.Date = model.Date;
        response.Permision = model.Permision;
        response.Owner = model.Owner;
        response.Items = items;

        return response;
    }
}
