using AutoMapper;
using CheckListDbContext.Context;
using CheckListService.Models;
using Common.Validator;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data.Entity.Infrastructure;

namespace CheckListService;
public class CheckListService : ICheckListService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;
    private readonly IModelValidator<AddCheckListModel> addCheckListModelValidator;
    private readonly IModelValidator<ShareCheckListModel> shareCheckListModelValidator;
    private readonly IModelValidator<UpdateCheckListModel> updateCheckListModelValidator;
    

    public CheckListService(IDbContextFactory<MainDbContext> contextFactory, IMapper mapper,
                            IModelValidator<AddCheckListModel> addCheckListModelValidator,
                            IModelValidator<ShareCheckListModel> shareCheckListModelValidator,
                            IModelValidator<UpdateCheckListModel> updateCheckListModelValidator        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
        this.addCheckListModelValidator = addCheckListModelValidator;
        this.shareCheckListModelValidator = shareCheckListModelValidator;
        this.updateCheckListModelValidator = updateCheckListModelValidator;
    }

    public async Task<IEnumerable<BookModel>> GetBooks(int offset = 0, int limit = 10)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var books = context
            .Books
            .Include(x => x.Author)
            .AsQueryable();

        books = books
            .Skip(Math.Max(offset, 0))
            .Take(Math.Max(0, Math.Min(limit, 1000)));

        var data = (await books.ToListAsync()).Select(book => mapper.Map<BookModel>(book));

        return data;
    }

    public async Task<BookModel> GetBook(int id)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var book = await context.Books.Include(x => x.Author).FirstOrDefaultAsync(x => x.Id.Equals(id));

        var data = mapper.Map<BookModel>(book);

        return data;
    }
    public async Task<BookModel> AddBook(AddBookModel model)
    {
        addBookModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var book = mapper.Map<Book>(model);
        await context.Books.AddAsync(book);
        context.SaveChanges();

        return mapper.Map<BookModel>(book);
    }

    public async Task UpdateBook(int bookId, UpdateBookModel model)
    {
        updateBookModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var book = await context.Books.FirstOrDefaultAsync(x => x.Id.Equals(bookId));

        ProcessException.ThrowIf(() => book is null, $"The book (id: {bookId}) was not found");

        book = mapper.Map(model, book);

        context.Books.Update(book);
        context.SaveChanges();
    }

    public async Task DeleteBook(int bookId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var book = await context.Books.FirstOrDefaultAsync(x => x.Id.Equals(bookId))
            ?? throw new ProcessException($"The book (id: {bookId}) was not found");

        context.Remove(book);
        context.SaveChanges();
    }
}
