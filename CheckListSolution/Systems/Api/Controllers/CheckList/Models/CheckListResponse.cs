using FluentValidation;

namespace Api.Controllers.CheckList.Models;
public class CheckListResponse
{
        public int IdList { get; set; }
        public string NameList { get; set; } = string.Empty;
        public DateTime DateList { get; set; }
        public string DescriptionList { get; set; } = string.Empty;
        public string OwnerList { get; set; } = string.Empty;
}
