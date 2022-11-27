using ToDo.Domain.Interface;
using ToDo.Infra.Data;

namespace ToDo.Web.Mvc.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IITemRepository, ItemRepository>();
            return services;
        }
    }
}
