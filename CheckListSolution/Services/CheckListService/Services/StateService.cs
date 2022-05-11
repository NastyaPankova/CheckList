using CheckListDbContext.Context;
using Common.Exeptions;
using Microsoft.EntityFrameworkCore;


namespace CheckListService;
public class StateService : IStateService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;

    public StateService(IDbContextFactory<MainDbContext> contextFactory)
    {
        this.contextFactory = contextFactory;
    }

    public async Task AddPermision(string Name)
    {
        var context = await contextFactory.CreateDbContextAsync();

        var permision = await context.Permisions
                        .FirstOrDefaultAsync(x => x.Name.ToLower().Equals(Name.ToLower()));

        ProcessException.ThrowIf(() => permision is not null, "Already exist");

        context.Permisions.AddAsync(permision);

        context.SaveChanges();
    }

    public async Task UpdatePermision(int PermisionId, string NewName)
    {
        var context = await contextFactory.CreateDbContextAsync();

        var permision = await context.Permisions
                        .FirstOrDefaultAsync(x => x.Id.Equals(PermisionId));

        ProcessException.ThrowIf(() => permision is null, "No such Permision");

        permision.Name = NewName;

        context.Permisions.Update(permision);

        context.SaveChanges();
    }

    public async Task DeletePermision(string Name)
    {
        var context = await contextFactory.CreateDbContextAsync();

        var permision = await context.Permisions
                        .FirstOrDefaultAsync(x => x.Name.ToLower().Equals(Name.ToLower()));

        ProcessException.ThrowIf(() => permision is null, "No such Permision");

        context.Permisions.Remove(permision);

        context.SaveChanges();
    }

    public async Task AddStatus(string Name)
    {
        var context = await contextFactory.CreateDbContextAsync();

        var status = await context.Statuses
                        .FirstOrDefaultAsync(x => x.Name.ToLower().Equals(Name.ToLower()));

        ProcessException.ThrowIf(() => status is not null, "Already exist");

        context.Statuses.AddAsync(status);

        context.SaveChanges();
    }

    public async Task UpdateStatus(int StatusId, string NewName)
    {
        var context = await contextFactory.CreateDbContextAsync();

        var status = await context.Statuses
                        .FirstOrDefaultAsync(x => x.Id.Equals(StatusId));

        ProcessException.ThrowIf(() => status is null, "No such Status");

        status.Name = NewName;

        context.Statuses.Update(status);

        context.SaveChanges();
    }

    public async Task DeleteStatus(string Name)
    {
        var context = await contextFactory.CreateDbContextAsync();

        var status = await context.Statuses
                        .FirstOrDefaultAsync(x => x.Name.ToLower().Equals(Name.ToLower()));

        ProcessException.ThrowIf(() => status is null, "No such Status");

        context.Statuses.Remove(status);

        context.SaveChanges();
    }

}