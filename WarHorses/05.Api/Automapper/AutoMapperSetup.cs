using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace _05.Api.Automapper{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
} 