﻿using Api.Controllers.CheckList.Models;
using CheckListService.Models;

namespace Api.Controllers.CheckList;

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

    public static CheckListByIdResponse ConvertToCheckListByIdResponse(this CheckListByIdModel model)
    {
        var items = model.Items.Select(d => d.ConvertToListItemResponse()).ToList();      

        var response = new CheckListByIdResponse();
        response.Id = model.Id;
        response.Name = model.Name;
        response.Description = model.Description;
        response.Date = model.Date;
        response.Permision = model.Permision;
        response.Owner = model.Owner;
        response.Items = items;

        return response;
    }
    public static CheckListResponse ConvertToCheckListResponse(this CheckListModel model)
    {
        var response = new CheckListResponse();
        response.Id = model.Id;
        response.Name = model.Name;
        response.Description = model.Description;
        response.Date = model.Date;
        response.Permision = model.Permision;

        return response;
    }

    public static AddCheckListModel ConvertToAddCheckListModel(this AddCheckListRequest request, Guid UserId)
    {
        var model = new AddCheckListModel();
        model.Name = request.Name;
        model.Description = request.Description;
        model.UserId = UserId;

        return model;
    }
}
