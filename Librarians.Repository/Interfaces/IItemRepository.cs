using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarians.Repository.Interfaces
{
    public interface IItemRepository<T>
    {
        Task<List<T>> GetAllItemsAsync();
        Task<List<T>> GetByIdAsync(int id);
        Task<T> AddAsync(T item);
        Task<T> UpdateAsync(int id, T item);
        Task<T> DeleteAsync(int id);
    }
}
