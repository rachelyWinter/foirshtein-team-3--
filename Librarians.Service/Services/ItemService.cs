using AutoMapper;
using Librarians.Common.Dto;
using Librarians.Repository.Entities;
using Librarians.Repository.Interfaces;
using Librarians.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarians.Service.Services
{
    public class ItemService:IItemService<ItemDto>
    {
        private readonly IItemRepository<Item> repository;
        private readonly IMapper mapper;
        public ItemService(IItemRepository<Item> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<List<ItemDto>> GetAllItemsAsync()
        {
            var items = await repository.GetAllItemsAsync();
            return await mapper.Map<Task<List<ItemDto>>>(items);
        }
        public async Task<ItemDto> GetItemById(int id)
        {
            var item = repository.GetByIdAsync(id);
            return await mapper.Map<Task<ItemDto>>(item);
        }

        public async Task<ItemDto> AddAsync(ItemDto item)
        {
            var itemToAdd=mapper.Map<Item>(item);
            var itemDto = await repository.AddAsync(itemToAdd);
            return mapper.Map<ItemDto>(itemDto);
        }
        public async Task<ItemDto> UpdateAsync(int id, ItemDto item)
        {
            var itemDto = await repository.UpdateAsync(id, mapper.Map<Item>(item));
            return mapper.Map<ItemDto>(itemDto);
        }
        public async Task<ItemDto> DeleteAsync(int id)
        {
            var item = await repository.DeleteAsync(id);
            return mapper.Map<ItemDto>(item);
        }

      
    }
}
