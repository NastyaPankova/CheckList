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
    public async Task<IEnumerable<CheckListResponse>> GetAllCheckLists([FromHeader] Guid UserId)
    {
        var data = await checkListService.GetCheckLists(UserId);

        return data.Select(d => d.ConvertToCheckListResponse()).ToList();
    }

    [HttpGet("({CheckListId}")]
    public async Task<CheckListByIdResponse> GetCheckListById([FromHeader] Guid UserId, int CheckListId)
    {
        var data = await checkListService.GetCheckListById(UserId, CheckListId);
        
        return data.ConvertToCheckListByIdResponse();
    }

    [HttpPost("")]
    public async Task<OkResult> AddCheckList ([FromHeader] Guid UserId, [FromBody] AddCheckListRequest request)
    {
        var model = request.ConvertToAddCheckListModel(UserId);
        await checkListService.AddCheckList(UserId, model);

        return Ok();

    }

    /*

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