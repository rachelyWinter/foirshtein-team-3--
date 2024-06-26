using Librarians.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarians.Repository.Interfaces
{
    public interface IContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Tag> Tags { get; set; }
        Task Save();
    }
}
