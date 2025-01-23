using Microsoft.Extensions.DependencyInjection;
using TorneoTenis.Aplicacion.Mappings;

namespace TorneoTenis.Aplicacion
{
    public static class ServiceExtension
    {
        public static void AddApplicationLayer(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(MappingProfile));
        }

    }
}
