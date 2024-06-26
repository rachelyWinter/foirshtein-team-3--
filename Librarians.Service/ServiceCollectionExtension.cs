using Librarians.Common.Dto;
using Librarians.Repository;
using Librarians.Repository.Entities;
using Librarians.Repository.Interfaces;
using Librarians.Service.Interfaces;
using Librarians.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarians.Service
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddRepository();
            services.AddScoped<IItemService<ItemDto>, ItemService>();
            services.AddScoped<ITagService<TagDto>, TagService>();
            services.AddAutoMapper(typeof(MapProfile));
            return services;
        }
    }
}
