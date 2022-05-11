using AutoMapper;
using CheckListDbContext.Context;
using CheckListService;
using CheckListService.Models;
using Common;
using Common.Exeptions;
using Common.Validator;
using DbEntities;
using Microsoft.EntityFrameworkCore;


namespace CheckListService;
public class ListItemService : IListItemService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IModelValidator<AddItemModel> addItemModelValidator;
    private readonly IModelValidator<UpdateItemModel> updateItemModelValidator;
    

    public ListItemService(IDbContextFactory<MainDbContext> contextFactory, 
                            IModelValidator<AddItemModel> addItemModelValidator,
                            IModelValidator<UpdateItemModel> updateItemModelValidator )
    {
        this.contextFactory = contextFactory;
        this.addItemModelValidator = addItemModelValidator;
        this.updateItemModelValidator = updateItemModelValidator;
    }

    public async Task AddItem(AddItemModel model)
    {
        addItemModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var isExist = await context.CheckLists.FirstOrDefaultAsync(x => x.Id.Equals(model.CheckListId));
        ProcessException.ThrowIf(() => isExist is null, "No such Check List");

        var checkList = await context.CheckLists.FirstOrDefaultAsync(x => x.Id.Equals(model.CheckListId));
        var status = await context.Statuses.FirstOrDefaultAsync(x => x.Name.ToLower().Equals(CommonConstants.Unmarked.ToLower()));
        var listItem = model.ConvertToItem(checkList, status);
       
        await context.ListItems.AddAsync(listItem);
     
        context.SaveChanges();
    }
    public async Task MarkItem(int ListItemId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var item = await context.ListItems.FirstOrDefaultAsync(x => x.Id.Equals(ListItemId));
        ProcessException.ThrowIf(() => item is null, "No such Item");

        var marked = await context.Statuses.FirstOrDefaultAsync(x => x.Name.ToLower().Equals(CommonConstants.Marked.ToLower()));
        var unmarked = await context.Statuses.FirstOrDefaultAsync(x => x.Name.ToLower().Equals(CommonConstants.Unmarked.ToLower()));

        if (item.Status.Name.ToLower().Equals(marked))
        {
            item.Status = unmarked;
            context.ListItems.Update(item);
            context.SaveChanges();
        }
        else
        {
            item.Status = marked;
            context.ListItems.Update(item);
            context.SaveChanges();
        }
    }
    public async Task UpdateItem(UpdateItemModel model)
    {
        updateItemModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var changedItem = await context.ListItems.FirstOrDefaultAsync(x => x.Id.Equals(model.ListItemId));
        var unmarked = await context.Statuses.FirstOrDefaultAsync(x => x.Name.ToLower().Equals(CommonConstants.Unmarked.ToLower()));
        changedItem = changedItem.ConvertToItem(model, unmarked);

        context.ListItems.Update(changedItem);

        context.SaveChanges();
    }
    public async Task DeleteItem(int ListItemId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var item = await context.ListItems.FirstOrDefaultAsync(x => x.Id.Equals(ListItemId));
        ProcessException.ThrowIf(() => item is null, "No such Item");
        
        context.ListItems.Remove(item);

        context.SaveChanges();

    }
}
