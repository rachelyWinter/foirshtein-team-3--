using AutoMapper;
using Librarians.Common.Dto;
using Librarians.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarians.Service
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Item, ItemDto>().ReverseMap();
            CreateMap<Task<Item>, Task<ItemDto>>().ReverseMap();
            CreateMap<Task<List<Item>>, Task<List<ItemDto>>>().ReverseMap();
            CreateMap<Tag, TagDto>().ReverseMap();
            CreateMap<Task<Tag>, Task<TagDto>>().ReverseMap();
            CreateMap<Task<List<Tag>>, Task<List<TagDto>>>().ReverseMap();
        }
    }
}
