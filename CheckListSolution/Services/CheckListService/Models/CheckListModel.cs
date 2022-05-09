using AutoMapper;
using DbEntities;

namespace CheckListService.Models;
public class CheckListModel
{
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public int PermisionId { get; set; }
}
public class CheckListModelProfile : Profile
{
    public CheckListModelProfile()
    {
        CreateMap<CheckList, CheckListModel>();
           
    }
}

