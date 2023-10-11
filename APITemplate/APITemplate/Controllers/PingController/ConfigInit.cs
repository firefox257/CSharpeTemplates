using APITemplate.Controllers.PingController.Data;
using Configuration;
using PingService;

namespace APITemplate.Controllers.PingController
{
    /// <summary>
    /// This class and its methods adds  context in the dependency injection pipeline for mapped items.
    /// </summary>
    public static class ConfigInit
    {

        static public void AddMappers()
        {
            ConfigMappers.CreateMap<ApiPingResponse, PingResponse>();
            ConfigMappers.CreateMap<PingResponse, ApiPingResponse>();
        }
    }
}
