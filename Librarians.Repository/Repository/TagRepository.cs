using Librarians.Repository.Entities;
using Librarians.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
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
    public class TagRepository : ITagRepository<Tag>
    {
        private readonly IContext? _context;

        public TagRepository(IContext _context)
        {
            this._context = _context;
        }
        public async Task<List<Tag>> GetAllTagsAsync()
        {
            return await _context.Tags.ToListAsync();
        }
        public async Task<List<Tag>> GetByIdAsync(int id)
        {
            return await _context.Tags.Where(i => i.Id == id).ToListAsync();

        }
        public async Task<Tag> AddAsync(Tag tag)
        {
             
            await _context.Tags.AddAsync(tag);
            await _context.Save();
            return tag;
        }
        public async Task<bool> TagExistsAsync(string tagName)
        {
            return await _context.Tags.AnyAsync(t => t.Name == tagName);
        }
        public async Task<Tag> UpdateAsync(int id, Tag tag)
        {
            var tagUpdate = await _context.Tags.FirstOrDefaultAsync(i => i.Id == id);
                tagUpdate.Name = tag.Name;
            await _context.Save();
            return tagUpdate;
        }

        public async Task<Tag> DeleteAsync(int id)
        {
            var tagDelete = await _context.Tags.FirstOrDefaultAsync(i => i.Id == id);
            _context.Tags.Remove(tagDelete);
            await _context.Save();
            return tagDelete;
        }
    }


}

