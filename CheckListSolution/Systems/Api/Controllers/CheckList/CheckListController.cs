namespace Api.Controllers.CheckList;

using Api.Controllers.CheckList.Models;
using CheckListService;
using Microsoft.AspNetCore.Mvc;

[Route("api/v{version:apiVersion}/checklists")]
[ApiController]
[ApiVersion("1.0")]

public class CheckListController : ControllerBase
{
    private readonly ILogger<CheckListController> logger;
    private readonly ICheckListService checkListService;

    public CheckListController(ILogger<CheckListController> logger, ICheckListService checkListService)
    {
        this.logger = logger;
        this.checkListService = checkListService;
    }

    [HttpPost("")]
    public CheckListResponse AddCheckList ([FromBody] AddCheckListRequest request)
    {
        CheckListResponse newCheckList = new CheckListResponse();
        newCheckList.Name = request.Name;
        newCheckList.Description = request.Description;
        newCheckList.IdUser = request.IdUser;
        return newCheckList;

    }
}