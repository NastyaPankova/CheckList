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
    

    public CheckListService(IDbContextFactory<MainDbContext> contextFactory, IMapper mapper,
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

    public async Task<IEnumerable<CheckListModel>> GetCheckLists(int offset = CommonConstants.Offset, 
                                                                 int limit = CommonConstants.LimitCheckLists)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        //CHANGE: добавить автора списка

        var checkLists = context.CheckLists.AsQueryable();

        checkLists = checkLists
            .Skip(Math.Max(offset, 0))
            .Take(Math.Max(0, Math.Min(limit, 1000)));

        var data = (await checkLists.ToListAsync()).Select(checkList => mapper.Map<CheckListModel>(checkList));

        return data;
    }

    public async Task<CheckListModel> GetCheckList(int id)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var checkList = await context.CheckLists.FirstOrDefaultAsync(x => x.Id.Equals(id));

        var data = mapper.Map<CheckListModel>(checkList);

        return data;
    }
    public async Task<CheckListModel> AddCheckList(AddCheckListModel model)
    {
        addCheckListModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

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
        context.SaveChanges();*/
    }

    public async Task DeleteCheckList(int id)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var checkList = await context.CheckLists.FirstOrDefaultAsync(x => x.Id.Equals(id));
        ProcessException.ThrowIf(() => checkList is null, $"CheckList (id: {id} was not found");

       //CHANGE: проверить права на список

        context.Remove(checkList);
        context.SaveChanges();
    }
}
