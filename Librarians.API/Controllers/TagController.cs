using Librarians.Common.Dto;
using Librarians.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Librarians.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagService<TagDto> _service;
        public TagController(ITagService<TagDto> service)
        {
            _service = service;
        }



        // GET: api/<TagsController>
        [HttpGet]
        public async Task<ActionResult<TagDto>> Get()
        {
            var tags = await _service.GetAllTagsAsync();
            if (tags == null || tags.Count == 0)
            {
                return Ok(new
                {
                    Status = "success",
                    Message = "No tags found",
                    Data = new List<TagDto>()
                });
            }
            return Ok(new
            {
                Status = "success",
                Message = "Tags retrieved successfully",
                Data = tags
            });
        }

        //// GET api/<TagsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<TagsController>
        [HttpPost]
        public async Task<ActionResult<TagDto>> Post([FromBody] TagDto tagDto)
        {
            if (await _service.TagExistsAsync(tagDto.Name))
                return Conflict(new
                {
                    Status = "error",
                    Message = "Tag with the same name already exists",
                    Data = tagDto
                });
            var result = await _service.AddAsync(tagDto);
            if (result is null)
                return NotFound(new
                {
                    status = "NotFound",
                    message = "Tag does not exist",
                    data = tagDto
                });

           else return Ok(new
            {
                Status = "success",
                Message = "Tag added successfully",
                Data = result
            });

        }

        // PUT api/<TagsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TagDto>> Put(int id, [FromBody] TagDto tagDto)
        {

            var existingTag = await _service.GetTagById(id);
            if (existingTag is null)
            {
                return NotFound(new
                {
                    Status = "error",
                    Message = "Tag does not exist",
                    Data = tagDto,
                });
            }
            if (await _service.TagExistsAsync(tagDto.Name))
            {
                return Conflict(new
                {
                    Status = "error",
                    Message = "There are two same tags there",
                    Data = tagDto
                });
            }
            var result = await _service.UpdateAsync(id, tagDto);
            return Ok(new
            {
                Status = "success",
                Message = "Tag updated successfully",
                Data = result
            }); ;

        }

        // DELETE api/<TagsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TagDto>> Delete(int id)
        {
            var existingTag = await _service.GetTagById(id);
            if (existingTag is null)
            {
                return NotFound(new
                {
                    Status = "error",
                    Message = "Tag does not exist",
                });
            }
            var result = await _service.DeleteAsync(id);
            return Ok(new
            {
                Status = "success",
                Message = "Tag deleted successfully",
                Data = result
            });

        }
    }
}
