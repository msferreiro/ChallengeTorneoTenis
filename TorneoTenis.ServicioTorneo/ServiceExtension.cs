using Microsoft.Extensions.DependencyInjection;
using TorneoTenis.Aplicacion.Interfaces.Servicios;


namespace TorneoTenis.Servicios
{
    public static class ServiceExtension
    {
        public static void AddServiceLayerInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IServicioTorneo, ServicioTorneo>();
        }
    }
}
