using CheckListService.Models;
using DbEntities;

namespace CheckListService;

public static class CheckListServiceModelMpper
{

    public static ListItemModel ConvertToListItemModel(this ListItemQuery query)
    {
        var item = new ListItemModel();
        item.Id = query.Id;
        item.Content = query.Content;
        item.Date = query.Date;
        item.Cost = query.Cost;
        item.Status = query.Status;

        return item;
    }
    public static CheckListModel ConvertToCheckListModel(this CheckListQuery query)
    {
        var model = new CheckListModel();
        model.Id = query.Id;
        model.Name = query.Name;
        model.Description = query.Description;
        model.Date = query.Date;
        model.Permision = query.Permision;
        return model;
    }
    public static CheckList ConvertToCheckList(this AddCheckListModel addModel)
    {
        var model = new CheckList();
        model.Name = addModel.Name;
        model.Description = addModel.Description;
        model.Date = DateTime.Now;
        return model;
    }

    public static CheckListByIdModel ConvertToCheckListByIdModel(this CheckListQuery query, 
                                                                string owner,
                                                                List<ListItemModel> items)
    {
        //var items = model.Items.Select(d => d.ConvertToListItemResponse()).ToList();      

        var model = new CheckListByIdModel();
        model.Id = query.Id;
        model.Name = query.Name;
        model.Description = query.Description;
        model.Date = query.Date;
        model.Permision = query.Permision;
        model.Owner = owner;
        model.Items = items;
        return model;
    }
}
