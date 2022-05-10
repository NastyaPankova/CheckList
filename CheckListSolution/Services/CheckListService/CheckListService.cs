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
    private readonly IMapper mapper;
    private readonly IModelValidator<AddCheckListModel> addCheckListModelValidator;
    private readonly IModelValidator<ShareCheckListModel> shareCheckListModelValidator;
    private readonly IModelValidator<UpdateCheckListModel> updateCheckListModelValidator;
    

    public CheckListService(IDbContextFactory<MainDbContext> contextFactory, 
                            IMapper mapper,
                            IModelValidator<AddCheckListModel> addCheckListModelValidator,
                            IModelValidator<ShareCheckListModel> shareCheckListModelValidator,
                            IModelValidator<UpdateCheckListModel> updateCheckListModelValidator        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
        this.addCheckListModelValidator = addCheckListModelValidator;
        this.shareCheckListModelValidator = shareCheckListModelValidator;
        this.updateCheckListModelValidator = updateCheckListModelValidator;
    }

    public async Task<IEnumerable<GetCheckListModel>> GetCheckLists(Guid UserId)
                                                                 
    {
        using var context = await contextFactory.CreateDbContextAsync();
        var data = from user in context.Users
                join checkListUser in context.CheckListUsers on user equals checkListUser.User
                join checkList in context.CheckLists on checkListUser.CheckList equals checkList
                join permision in context.Permisions on checkListUser.Permision equals permision
                where user.Id == UserId
                select new 
                {
                     Id = checkList.Id,
                     Name = checkList.Name,
                     Description = checkList.Description,
                     Date = checkList.Date,
                     Permision = permision.Name
                 };
        var allLists = new List<GetCheckListModel>();
        foreach (var d in data)
        {
            var getCheckListModel = new GetCheckListModel()
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,
                Date = d.Date,
                Permision = d.Permision
            };
            allLists.Add(getCheckListModel);
        }
        
        return allLists.AsQueryable();
    }

    public async Task<GetCheckListByIdModel> GetCheckListById(Guid UserId, int CheckListId)

    {
        using var context = await contextFactory.CreateDbContextAsync();

        var isCheckList = await context.CheckLists.FirstOrDefaultAsync(x => x.Id.Equals(CheckListId));
        ProcessException.ThrowIf(() => isCheckList is null, "No such Check List");

        var isAccess = await context.CheckListUsers
                       .FirstOrDefaultAsync(x => (x.CheckListId.Equals(CheckListId)) & (x.UserId.Equals(UserId)));
        ProcessException.ThrowIf(() => isAccess is null, "No access for this user");

        var getCheckListByIdModel = new GetCheckListByIdModel();
        var data = await     (from user in context.Users
                              join checkListUser in context.CheckListUsers on user equals checkListUser.User
                              join checkList in context.CheckLists on checkListUser.CheckList equals checkList
                              join permision in context.Permisions on checkListUser.Permision equals permision
                              where (checkList.Id == CheckListId) & (user.Id == UserId)
                              select new
                              {
                                   Id = checkList.Id,
                                   Name = checkList.Name,
                                   Description = checkList.Description,
                                   Date = checkList.Date,
                                   Permision = permision.Name
                              }).FirstOrDefaultAsync();
        var owner = await (from user in context.Users
                          join checkListUser in context.CheckListUsers on user equals checkListUser.User
                          join checkList in context.CheckLists on checkListUser.CheckList equals checkList
                          join permision in context.Permisions on checkListUser.Permision equals permision
                          where (checkList.Id == CheckListId) & (permision.Name.ToLower().Equals("creator") )
                          select user.Name).FirstOrDefaultAsync();
        getCheckListByIdModel.Id = data.Id;
        getCheckListByIdModel.Name = data.Name;
        getCheckListByIdModel.Description = data.Description;
        getCheckListByIdModel.Date = data.Date;
        getCheckListByIdModel.Permision = data.Permision;
        getCheckListByIdModel.Owner = owner;

        return getCheckListByIdModel;
    }

   /* public async Task<CheckListModel> GetCheckList(int checkListId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var checkList = await context.CheckLists.FirstOrDefaultAsync(x => x.Id.Equals(checkListId));

        var data = mapper.Map<CheckListModel>(checkList);

        return data;
    }
    public async Task<CheckListModel> AddCheckList(AddCheckListModel model)
    {
        addCheckListModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        model.Date = DateTime.Now;
        var checkList = mapper.Map<CheckList>(model);
        await context.CheckLists.AddAsync(checkList);
        context.SaveChanges();

        return mapper.Map<CheckListModel>(checkList);
    }

    public async Task UpdateCheckList(UpdateCheckListModel model)
    {
        updateCheckListModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var checkList = await context.CheckLists.FirstOrDefaultAsync(x => x.Id.Equals(model.CheckListId));

        ProcessException.ThrowIf(() => checkList is null, $"CheckList (id: {model.CheckListId} was not found");

        checkList = mapper.Map(model, checkList);

        context.CheckLists.Update(checkList);
        context.SaveChanges();
    }

    public async Task ShareCheckList(ShareCheckListModel model) //CHANGE: СДЕЛАТЬ!
    {
       /* shareCheckListModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var checkList = await context.CheckLists.FirstOrDefaultAsync(x => x.Id.Equals(model.CheckListId));
        ProcessException.ThrowIf(() => checkList is null, $"CheckList (id: {model.CheckListId} was not found");

        checkList = mapper.Map(model, checkList);

        context.CheckLists.Update(checkList);
        context.SaveChanges();
    }

   /* public async Task DeleteCheckList(int id)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var checkList = await context.CheckLists.FirstOrDefaultAsync(x => x.Id.Equals(id));
        ProcessException.ThrowIf(() => checkList is null, $"CheckList (id: {id} was not found");

       //CHANGE: проверить права на список

        context.Remove(checkList);
        context.SaveChanges();
    }*/
}
