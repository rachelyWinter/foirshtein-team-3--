using Librarians.Repository.Entities;
using Librarians.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarians.Repository.Repository
{
    public class ItemRepository : IItemRepository<Item>
    {

        private readonly IContext? _context;

        public ItemRepository(IContext _context)
        {
            this._context = _context;
        }
        public async Task<List<Item>> GetAllItemsAsync()
        {
            return await _context.Items.ToListAsync();
        }
        public async Task<List<Item>> GetByIdAsync(int id)
        {
            return await _context.Items.Where(i => i.Id == id).ToListAsync();
        }
        public async Task<Item> AddAsync(Item item)
        {
            await _context.Items.AddAsync(item);
            await _context.Save();
            return item;
        }
        public async Task<Item> UpdateAsync(int id, Item item)
        {
            var itemUpdate = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
            itemUpdate.Title = item.Title;
            itemUpdate.Category = item.Category;
            itemUpdate.CreatedAt = item.CreatedAt;
            itemUpdate.Author = item.Author;
            itemUpdate.Description = item.Description;
            itemUpdate.FilePath = item.FilePath;
            itemUpdate.UpdatedAt = item.UpdatedAt;
            await _context.Save();
            return itemUpdate;
        }
        public async Task<Item> DeleteAsync(int id)
        {
            var itemDelete = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
            _context.Items.Remove(itemDelete);
            await _context.Save();
            return itemDelete;
        }
    }
}
