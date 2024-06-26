using Librarians.Repository.Entities;
using Librarians.Repository.Interfaces;
using Librarians.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarians.Repository
{
    public static class RepositoryCollectionExtension
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IItemRepository<Item>,ItemRepository> ();
            services.AddScoped<ITagRepository<Tag>, TagRepository>();
            return services;
        }
    }
}
