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
    public class TagService : ITagService<TagDto>
    {
        private readonly ITagRepository<Tag> repository;
        private readonly IMapper mapper;
        public TagService(ITagRepository<Tag> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<List<TagDto>> GetAllTagsAsync()
        {
            var tags = await mapper.Map<Task<List<TagDto>>>(repository.GetAllTagsAsync());
            return tags;
        }
        public async Task<TagDto> GetTagById(int id)
        {
            var tag = await repository.GetByIdAsync(id);
            return mapper.Map<TagDto>(tag);
        }

        public async Task<TagDto> AddAsync(TagDto tagDto)
        {
            var newTag = await repository.AddAsync(mapper.Map<Tag>(tagDto));
            return mapper.Map<TagDto>(newTag);
        }
        public async Task<bool> TagExistsAsync(string tagName)
        {
            return await repository.TagExistsAsync(tagName);
        }
        public async Task<TagDto> DeleteAsync(int id)
        {
            var tag = await repository.DeleteAsync(id);
            return mapper.Map<TagDto>(tag);
        }

        public async Task<TagDto> UpdateAsync(int id, TagDto tagDto)
        {
            var tagToUpdate = mapper.Map<Tag>(tagDto);
            var tagAfterUpdate = await repository.UpdateAsync(id, tagToUpdate);
            return mapper.Map<TagDto>(tagAfterUpdate);
        }

        
    }
}
