namespace Api.Controllers.CheckList;

using Api.Controllers.CheckList.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/v{version:apiVersion}/checklists")]
[ApiController]
[ApiVersion("1.0")]

public class CheckListController : ControllerBase
{
    private readonly ILogger<CheckListController> logger;

    [HttpGet("")]
    public List<CheckList> GetList()
    {
        return new List<CheckList>()
        {
            new CheckList() { IdList = 1, NameList = "First List" }
        };
    }

}