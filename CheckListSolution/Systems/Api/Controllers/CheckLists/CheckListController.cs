namespace Api.Controllers.CheckList;

using Api.Controllers.CheckList.Models;
using AutoMapper;
using CheckListService;
using CheckListService.Models;
using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/v{version:apiVersion}/checklists")]
[ApiController]
[ApiVersion("1.0")]
//[Authorize("api")]

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

    /*[HttpPost("")]
    public async Task<CheckListResponse> AddCheckList ([FromBody] AddCheckListRequest request)
    {
        var model = mapper.Map<AddCheckListModel>(request);
        var checkList = await checkListService.AddCheckList(model);
        var response = mapper.Map<CheckListResponse>(checkList);
        return response;

    }*/
    [HttpGet("{UserId}")]
    public async Task<IEnumerable<GetCheckListResponse>> GetAllCheckLists(Guid UserId)
    {
        var data = await checkListService.GetCheckLists(UserId);
        var response = new List<GetCheckListResponse>();
        foreach (var d in data)
        {
            var getAllCheckListsResponse = new GetCheckListResponse()
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,
                Date = d.Date,
                Permision = d.Permision
            };
            response.Add(getAllCheckListsResponse);
        }
        return response;
    }

    [HttpGet("({checkListId}")]
    public async Task<GetCheckListByIdResponse> GetCheckListById(Guid UserId, int checkListId)
    {
        var data = await checkListService.GetCheckListById(UserId, checkListId);
        var response = new GetCheckListByIdResponse();
            response.Id = data.Id;
            response.Name = data.Name;
            response.Description = data.Description;
            response.Date = data.Date;
            response.Permision = data.Permision;
            response.Owner = data.Owner;
        return response;
    }


    /*[HttpGet("{id}")]
    [Authorize(AppScopes.BooksRead)]
    public async Task<BookResponse> GetBookById([FromRoute] int id)
    {
        var book = await bookService.GetBook(id);
        var response = mapper.Map<BookResponse>(book);

        return response;
    }

    [HttpPost("")]
    [Authorize(AppScopes.BooksWrite)]
    public async Task<BookResponse> AddBook([FromBody] AddBookRequest request)
    {
        var model = mapper.Map<AddBookModel>(request);
        var book = await bookService.AddBook(model);
        var response = mapper.Map<BookResponse>(book);

        return response;
    }

    [HttpPut("{id}")]
    [Authorize(AppScopes.BooksWrite)]
    public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromBody] UpdateBookRequest request)
    {
        var model = mapper.Map<UpdateBookModel>(request);
        await bookService.UpdateBook(id, model);

        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(AppScopes.BooksWrite)]
    public async Task<IActionResult> DeleteBook([FromRoute] int id)
    {
        await bookService.DeleteBook(id);

        return Ok();
    }*/
}