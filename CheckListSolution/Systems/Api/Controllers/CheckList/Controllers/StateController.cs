namespace Api.Controllers.CheckList;

using Api.Controllers.CheckList.Models;
using CheckListService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/v{version:apiVersion}/states")]
[ApiController]
[ApiVersion("1.0")]
[Authorize("api")]

public class StateController : ControllerBase
{
    private readonly ILogger<ListItemController> logger;
    private readonly IStateService stateService;

    public StateController(ILogger<ListItemController> logger, IStateService stateService)
    {
        this.logger = logger;
        this.stateService = stateService;
    }

    [HttpPost("permisions")]
    public async Task<OkResult> AddPermision ([FromBody] string Name)
    {
        if (string.IsNullOrEmpty(Name))
            throw new ArgumentNullException("Name is empty");
        await stateService.AddPermision(Name);
        return Ok();
    }

    [HttpPost("statuses")]
    public async Task<OkResult> AddStatus([FromBody] string Name)
    {
        if (string.IsNullOrEmpty(Name))
            throw new ArgumentNullException("Name is empty");
        await stateService.AddStatus(Name);
        return Ok();
    }

    [HttpPut("{PermisionId}")]
    public async Task<OkResult> UpdatePermision([FromRoute] int PermisionId, [FromBody] string Name)
    {
        if (string.IsNullOrEmpty(Name))
            throw new ArgumentNullException("Name is empty");
        await stateService.UpdatePermision(PermisionId, Name);
        return Ok();
    }

    [HttpPut("{StatusId}")]
    public async Task<OkResult> UpdateStatus([FromRoute] int StatusId, [FromBody] string Name)
    {
        if (string.IsNullOrEmpty(Name))
            throw new ArgumentNullException("Name is empty");
        await stateService.UpdateStatus(StatusId, Name);
        return Ok();
    }

    [HttpDelete("permisions")]
    public async Task<OkResult> DeletePermision([FromBody] string Name)
    {
        if (string.IsNullOrEmpty(Name))
            throw new ArgumentNullException("Name is empty");
        await stateService.DeletePermision(Name);
        return Ok();
    }

    [HttpDelete("statuses")]
    public async Task<OkResult> DeleteStatuses([FromBody] string Name)
    {
        if (string.IsNullOrEmpty(Name))
            throw new ArgumentNullException("Name is empty");
        await stateService.DeleteStatus(Name);
        return Ok();
    }
}