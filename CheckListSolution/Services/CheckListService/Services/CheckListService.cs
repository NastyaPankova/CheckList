using AutoMapper;
using CheckListDbContext.Context;
using CheckListService.Models;
using Common;
using Common.Exeptions;
using Common.Validator;
using DbEntities;
using Microsoft.EntityFrameworkCore;


namespace CheckListService;
public class CheckListService : ICheckListService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IModelValidator<AddCheckListModel> addCheckListModelValidator;
    private readonly IModelValidator<ShareCheckListModel> shareCheckListModelValidator;
    private readonly IModelValidator<UpdateCheckListModel> updateCheckListModelValidator;
    

    public CheckListService(IDbContextFactory<MainDbContext> contextFactory, 
                            IModelValidator<AddCheckListModel> addCheckListModelValidator,
                            IModelValidator<ShareCheckListModel> shareCheckListModelValidator,
                            IModelValidator<UpdateCheckListModel> updateCheckListModelValidator)
    {
        this.contextFactory = contextFactory;
        this.addCheckListModelValidator = addCheckListModelValidator;
        this.shareCheckListModelValidator = shareCheckListModelValidator;
        this.updateCheckListModelValidator = updateCheckListModelValidator;
    }

    public async Task<IEnumerable<CheckListModel>> GetCheckLists(Guid UserId)
                                                                 
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var data = context.CheckListUsers
                   .Include(k => k.CheckList).Include(k => k.User).Include(k => k.Permision)
                   .Where(w => w.UserId == UserId)
                   .Select(s => new CheckListQuery
                   {
                       Id = s.CheckListId,
                       Name = s.CheckList.Name,
                       Description = s.CheckList.Description,
                       Date = s.CheckList.Date,
                       Permision = s.Permision.Name
                   });

        return data.Select(d => d.ConvertToCheckListModel()).ToList().AsQueryable();
    }

    public List<ListItemModel> GetCheckListItems(int CheckListId)
    {
        using var context = contextFactory.CreateDbContext();

        var items = context.ListItems
                    .Include(s => s.Status)
                     .Where(item => item.CheckList.Id == CheckListId)
                     .Select (i => new ListItemQuery
                     {
                         Id = i.Id,
                         Content = i.Content,
                         Date = i.Date,
                         Cost = i.Cost,
                         Status = i.Status.Name
                     });

        return items.Select(d => d.ConvertToListItemModel()).ToList();
    }

    public async Task<CheckListByIdModel> GetCheckListById(Guid UserId, int CheckListId)

    {
        using var context = await contextFactory.CreateDbContextAsync();

        var isCheckList = await context.CheckLists.FirstOrDefaultAsync(x => x.Id.Equals(CheckListId));
        ProcessException.ThrowIf(() => isCheckList is null, "No such Check List");

        var isAccess = await context.CheckListUsers
                       .FirstOrDefaultAsync(x => (x.CheckListId.Equals(CheckListId)) & (x.UserId.Equals(UserId)));
        ProcessException.ThrowIf(() => isAccess is null, "No access for this user");

        var data = await  context.CheckListUsers
                  .Include(k => k.CheckList).Include(k => k.User).Include(k => k.Permision)
                  .Where(w => (w.UserId == UserId) & (w.CheckList.Id == CheckListId))
                  .Select(s => new CheckListQuery
                  {
                      Id = s.CheckListId,
                      Name = s.CheckList.Name,
                      Description = s.CheckList.Description,
                      Date = s.CheckList.Date,
                      Permision = s.Permision.Name
                  }).FirstOrDefaultAsync();

        var owner = await context.CheckListUsers
                          .Include(k => k.CheckList).Include(k => k.User).Include(k => k.Permision)
                          .Where(w => (w.Permision.Name.ToLower().Equals(CommonConstants.Creator.ToLower())) & (w.CheckList.Id == CheckListId))
                          .Select(s => s.User.Name).FirstOrDefaultAsync();
                         

        var items = GetCheckListItems(CheckListId);

        return data.ConvertToCheckListByIdModel(owner, items);
    }

    public async Task AddCheckList(AddCheckListModel model)
    {
        addCheckListModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var isGuid = await context.Users.FirstOrDefaultAsync(x => x.Id.Equals(model.UserId));
        ProcessException.ThrowIf(() => isGuid is null, "No such User");

        var newCheckList = model.ConvertToCheckList();
        var creator = await context.Users.FirstOrDefaultAsync(x => x.Id.Equals(model.UserId));
        var permision = await context.Permisions.FirstOrDefaultAsync(x => x.Name.ToLower().Equals(CommonConstants.Creator.ToLower()));
        var checkListUser = new CheckListUser { CheckList = newCheckList, User = creator, Permision = permision};

        await context.CheckLists.AddAsync(newCheckList);
        await context.CheckListUsers.AddAsync(checkListUser);
       
        context.SaveChanges();
    }
    public async Task ShareCheckList(ShareCheckListModel model)
    {
        shareCheckListModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var isGuid = await context.Users.FirstOrDefaultAsync(x => x.Id.Equals(model.UserId));
        ProcessException.ThrowIf(() => isGuid is null, "No such User");

        var isEmail = await context.Users.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(model.Email.ToLower()));
        ProcessException.ThrowIf(() => isEmail is null, "No such User in the app");

        var isAccess = await context.CheckListUsers
                            .Include(k => k.CheckList).Include(k => k.User).Include(k => k.Permision)
                            .Where(w => 
                            (w.Permision.Name.ToLower().Equals(CommonConstants.Creator.ToLower()))
                            & (w.CheckList.Id == model.CheckListId)
                            & (w.User.Id == model.UserId))
                            .FirstOrDefaultAsync();

        ProcessException.ThrowIf(() => isAccess is null, "Just for owner");

        var recipientId = await context.Users
                          .Where(w => w.Email.ToLower().Equals(model.Email.ToLower()))
                          .Select(x => x.Id).FirstOrDefaultAsync();

        var permision = await context.Permisions.FirstOrDefaultAsync(x => x.Name.ToLower().Equals(CommonConstants.Reader.ToLower()));

        var checkListUser = new CheckListUser { CheckListId = model.CheckListId, UserId = recipientId, Permision = permision };

        var isExist = await context.CheckListUsers.FirstOrDefaultAsync(x => x.Equals(checkListUser));
        ProcessException.ThrowIf(() => isExist is not null, "Already shared");

        await context.CheckListUsers.AddAsync(checkListUser);

        context.SaveChanges();
    }
    public async Task UpdateCheckList(UpdateCheckListModel model)
    {
        updateCheckListModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var isCheckList = await context.CheckLists.FirstOrDefaultAsync(x => x.Id.Equals(model.CheckListId));
        ProcessException.ThrowIf(() => isCheckList is null, "No such Check List");

        var isAccess = await context.CheckListUsers
                       .FirstOrDefaultAsync(x => 
                       (x.CheckListId.Equals(model.CheckListId)) 
                       & (x.UserId.Equals(model.UserId))
                       & (x.Permision.Name.ToLower().Equals(CommonConstants.Creator.ToLower())));
        ProcessException.ThrowIf(() => isAccess is null, "Just for owner");

        var changedCheckList = await context.CheckLists.FirstOrDefaultAsync(x => x.Id.Equals(model.CheckListId));
        changedCheckList = changedCheckList.ConvertToCheckList(model);

        context.CheckLists.Update(changedCheckList);

        context.SaveChanges();
    }
    public async Task DeleteCheckList(Guid UserId, int CheckListId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var isCheckList = await context.CheckLists.FirstOrDefaultAsync(x => x.Id.Equals(CheckListId));
        ProcessException.ThrowIf(() => isCheckList is null, "No such Check List");

        var isAccess = await context.CheckListUsers
                       .FirstOrDefaultAsync(x =>
                       (x.CheckListId.Equals(CheckListId))
                       & (x.UserId.Equals(UserId))
                       & (x.Permision.Name.ToLower().Equals(CommonConstants.Creator.ToLower())));
        ProcessException.ThrowIf(() => isAccess is null, "Just for owner");

        var checkList = await context.CheckLists.FirstOrDefaultAsync(x => x.Id.Equals(CheckListId));
    
        context.CheckLists.Remove(checkList);

        context.SaveChanges();

    }
}
