namespace Api.Controllers.CheckList;

using Api.Controllers.CheckList.Models;
using CheckListService;
using Microsoft.AspNetCore.Mvc;

[Route("api/v{version:apiVersion}/checklists")]
[ApiController]
[ApiVersion("1.0")]
//[Authorize("api")]

public class CheckListController : ControllerBase
{
    private readonly ILogger<CheckListController> logger;
    private readonly ICheckListService checkListService;

    public CheckListController(ILogger<CheckListController> logger, ICheckListService checkListService)
    {
        this.logger = logger;
        this.checkListService = checkListService;
    }

    [HttpGet("")]
    //ToDo: change UserId by Authorization
    public async Task<IEnumerable<CheckListResponse>> GetAllCheckLists([FromQuery] Guid UserId)
    {
        var data = await checkListService.GetCheckLists(UserId);

        return data.Select(d => d.ConvertToCheckListResponse()).ToList();
    }

    [HttpGet("{CheckListId}")]
    public async Task<CheckListByIdResponse> GetCheckListById([FromQuery] Guid UserId, [FromRoute] int CheckListId)
    {
        var data = await checkListService.GetCheckListById(UserId, CheckListId);
        
        return data.ConvertToCheckListByIdResponse();
    }

    [HttpPost("")]
    public async Task<OkResult> AddCheckList ([FromQuery] Guid UserId, [FromBody] AddCheckListRequest request)
    {
        var model = request.ConvertToAddCheckListModel(UserId);
        await checkListService.AddCheckList(model);

        return Ok();
    }

    [HttpPut("Share")]
    public async Task<OkResult> ShareCheckList ([FromQuery] Guid UserId, [FromBody] ShareCheckListRequest request)
    {
        var model = request.ConvertToShareCheckListModel(UserId);
        await checkListService.ShareCheckList(model);

        return Ok();
    }

    [HttpPut("")]
    public async Task<OkResult> UpdateCheckList([FromQuery] Guid UserId, [FromBody] UpdateCheckListRequest request)
    {
        var model = request.ConvertToUpdateCheckListModel(UserId);
        await checkListService.UpdateCheckList(model);

        return Ok();
    }

    [HttpDelete("{CheckListId}")]
    public async Task<OkResult> UpdateCheckList([FromQuery] Guid UserId, [FromRoute] int CheckListId)
    {
        await checkListService.DeleteCheckList(UserId, CheckListId);
        return Ok();
    }
}