﻿using AutoMapper;
using CheckListService.Models;

namespace Api.Controllers.CheckList.Models;
public class CheckListResponse
{
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int PermisionId { get; set; }
}
public class CheckListResponseProfile : Profile
{
    public CheckListResponseProfile()
    {
        CreateMap<CheckListModel, CheckListResponse>();
    }
}
