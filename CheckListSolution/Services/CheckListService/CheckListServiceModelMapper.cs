using CheckListService.Models;
using Common;
using DbEntities;


namespace CheckListService;

public static class CheckListServiceModelMapper
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
    public static ListItem ConvertToItem(this AddItemModel model)
    {
        var item = new ListItem();
        item.Content = model.Content;
        item.Date = DateTime.Now;
        item.Cost = model.Cost;
        return item;
    }

    public static ListItem ConvertToItem(this ListItem item, UpdateItemModel updModel, Status status)
    {
        item.Content = updModel.Content;
        item.Date = DateTime.Now;
        item.Cost = updModel.Cost;
        item.Status = status;
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

    public static CheckList ConvertToCheckList(this CheckList checkList, UpdateCheckListModel updModel)
    {
        checkList.Name = updModel.Name;
        checkList.Description = updModel.Description;
        checkList.Date = DateTime.Now;
        return checkList;
    }
}
