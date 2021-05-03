using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static void RegisterHandlers(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }

    }
}
