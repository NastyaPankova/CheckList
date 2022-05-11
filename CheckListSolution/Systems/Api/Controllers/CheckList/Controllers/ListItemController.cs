namespace Api.Controllers.CheckList;

using Api.Controllers.CheckList.Models;
using CheckListService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/v{version:apiVersion}/listitems")]
[ApiController]
[ApiVersion("1.0")]
[Authorize("api")]

public class ListItemController : ControllerBase
{
    private readonly ILogger<ListItemController> logger;
    private readonly IListItemService listItemService;

    public ListItemController(ILogger<ListItemController> logger, IListItemService listItemService)
    {
        this.logger = logger;
        this.listItemService = listItemService;
    }

    //ToDo: change UserId by Authorization
    [HttpPost("")]
    public async Task<OkResult> AddItem([FromBody] AddItemRequest request)
    {
        var model = request.ConvertToAddItemModel();
        await listItemService.AddItem(model);

        return Ok();
    }

    [HttpPut("{ListItemId}")]
    public async Task<OkResult> UpdateItem([FromRoute] int ListItemId, [FromRoute] int CheckListId, [FromBody] UpdateItemRequest request)
    {
        var model = request.ConvertToUpdateItemModel(ListItemId, CheckListId);
        await listItemService.UpdateItem(model);

        return Ok();
    }

    [HttpPut("mark/{ListItemId}")]
    public async Task<OkResult> MarkItem([FromRoute] int ListItemId)
    {
        await listItemService.MarkItem(ListItemId);

        return Ok();
    }

    [HttpDelete("{ListItemId}")]
    public async Task<OkResult> UpdateCheckList([FromRoute] int ListItemId)
    {
        await listItemService.DeleteItem(ListItemId);
        return Ok();
    }
}