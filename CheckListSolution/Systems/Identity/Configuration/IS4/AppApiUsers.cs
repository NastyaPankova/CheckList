namespace Identity.Configuration.IS4;

using Duende.IdentityServer.Test;

public static class AppApiUsers
{
    public static List<TestUser> ApiUsers =>
        new List<TestUser>
        {
            new TestUser
            {
                SubjectId = "1",
                Username = "username",
                Password = "password"
            }
        };
}