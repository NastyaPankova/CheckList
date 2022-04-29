using FluentValidation;

namespace Api.Controllers.CheckList.Models;
public class CheckListResponse
{
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public int IdUser { get; set; }
}
