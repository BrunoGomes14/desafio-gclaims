using MediatR;
using api.Repository;
using System.Reflection;
using api.Requests;

namespace api.Util
{
    public static class DependenciesExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSingleton<IRepository, CharactersRepository>();
            services.AddSingleton<IRequests, MavelHttpRequest>();
        }
    }
}