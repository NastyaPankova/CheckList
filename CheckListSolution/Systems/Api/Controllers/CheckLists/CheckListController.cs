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
[Authorize("api")]

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

    }
    [HttpGet("")]
    public async Task<IEnumerable<CheckListResponse>> GetBooks([FromQuery] int offset = CommonConstants.Offset, 
                                                               [FromQuery] int limit = CommonConstants.LimitCheckLists)
    {
        var books = await checkListService.(offset, limit);
        var response = mapper.Map<IEnumerable<BookResponse>>(books);

        return response;
    }

    [HttpGet("{id}")]
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