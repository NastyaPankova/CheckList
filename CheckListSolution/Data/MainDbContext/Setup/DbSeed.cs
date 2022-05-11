using CheckListDbContext.Context;
using DbEntities;
using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CheckListDbContext.Setup;
public static class DbSeed
{
    public static void AddData(MainDbContext context)
    {
        if (context.Permisions.Any() || context.CheckListUsers.Any())
            return;

        var creator = new Permision() { Name = CommonConstants.Creator };
        context.Permisions.Add(creator);

        var reader = new Permision() { Name = CommonConstants.Reader };
        context.Permisions.Add(reader);

        var marked = new Status() { Name = CommonConstants.Marked };
        context.Statuses.Add(marked);

        var unmarked = new Status() { Name = CommonConstants.Unmarked };
        context.Statuses.Add(unmarked);

        var test_user_1 = new User { Name = "Alex", Email = "Alex@com" };
        context.Users.Add(test_user_1);

        var test_user_2 = new User { Name = "Oleg", Email = "Oleg@com" };
        context.Users.Add(test_user_2);

        var test_user_3 = new User { Name = "Tommy", Email = "Tommy@com" };
        context.Users.Add(test_user_3);

        var test_user_4 = new User { Name = "Mark", Email = "Mark@com"};
        context.Users.Add(test_user_4);

        var checkList_1 = new CheckList { Name = "List 1", Description = "New test Check List",  Date = DateTime.Now};
        context.CheckLists.Add(checkList_1);

        var checkList_2 = new CheckList { Name = "List 2", Description = "My test Check List", Date = DateTime.Now };
        context.CheckLists.Add(checkList_2);

        var checkList_3 = new CheckList { Name = "List 3", Date = DateTime.Now };
        context.CheckLists.Add(checkList_3);

        var checkListUser_1 = new CheckListUser 
        { 
            User = test_user_1, 
            CheckList = checkList_1, 
            Permision = creator 
        };
        context.CheckListUsers.Add(checkListUser_1);

        var checkListUser_2 = new CheckListUser
        {
            User = test_user_2,
            CheckList = checkList_2,
            Permision = creator
        };
        context.CheckListUsers.Add(checkListUser_2);

        var checkListUser_3 = new CheckListUser
        {
            User = test_user_3,
            CheckList = checkList_2,
            Permision = reader
        };
        context.CheckListUsers.Add(checkListUser_3);

        var listItem_1 = new ListItem { Content = "New Item in list", Status = unmarked, CheckList = checkList_1};
        context.ListItems.Add(listItem_1);

        var listItem_2 = new ListItem { Content = "Marked Item in list", Status = marked, CheckList = checkList_1 };
        context.ListItems.Add(listItem_2);

        context.SaveChanges();
    }
    
    public static void Execute(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.GetService<IServiceScopeFactory>()?.CreateScope();
        ArgumentNullException.ThrowIfNull(scope);

        var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<MainDbContext>>();
        using var context = factory.CreateDbContext();

        AddData(context);

    }
}