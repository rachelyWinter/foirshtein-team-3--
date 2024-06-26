using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarians.Service.Interfaces
{
    public interface IItemService<T>
    {
        Task<List<T>> GetAllItemsAsync();
        Task<T> GetItemById(int id);
        Task<T> AddAsync(T item);
        Task<T> UpdateAsync(int id, T item);
        Task<T> DeleteAsync(int id);
    }
}
