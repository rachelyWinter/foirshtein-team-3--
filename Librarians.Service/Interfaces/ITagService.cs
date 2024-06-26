using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarians.Service.Interfaces
{
    public interface ITagService<T>
    {
        Task<List<T>> GetAllTagsAsync();
        Task<T> GetTagById(int id);
        Task<T> AddAsync(T tag);
        Task<T> UpdateAsync(int id, T tag);
        Task<T> DeleteAsync(int id);
        Task<bool> TagExistsAsync(string name);
    }
}
