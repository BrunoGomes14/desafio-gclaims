using MediatR;
using api.Repository;
using System.Reflection;
using api.Requests;

namespace api.Util
{
    public static class DependenciesExtension
    {
        public static void AddDependencies(this WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
            builder.Services.AddSingleton<IRepository, CharactersRepository>();
            builder.Services.AddSingleton<IRequests, MavelHttpRequest>();

            var config = builder.Configuration.Get<AppSettings>();
            builder.Services.AddSingleton<MarvelConfig>(config.MarvelConfig!);
        }
    }
}