namespace Api.Controllers.CheckList;

using Api.Controllers.CheckList.Models;
using AutoMapper;
using CheckListService;
using CheckListService.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/v{version:apiVersion}/checklists")]
[ApiController]
[ApiVersion("1.0")]

public class CheckListController : ControllerBase
{
    private readonly ILogger<CheckListController> logger;
    private readonly ICheckListService checkListService;
    private readonly IMapper mapper;

    public CheckListController(IMapper mapper, ILogger<CheckListController> logger, ICheckListService checkListService)
    {
        this.logger = logger;
        this.checkListService = checkListService;
        this.mapper = mapper;
    }

    [HttpPost("")]
    public async Task<CheckListResponse> AddCheckList ([FromBody] AddCheckListRequest request)
    {
        var model = mapper.Map<AddCheckListModel>(request);
        var checkList = await checkListService.AddCheckList(model);
        var response = mapper.Map<CheckListResponse>(checkList);
        return response;

    }
}