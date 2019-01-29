using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Sitecore.Pipelines;
using System.Web.Http;

namespace satellite_api.Processors
{
    public class RegisterApiRoutes
    {
        public void Process(PipelineArgs args)
        {
            HttpConfiguration config = GlobalConfiguration.Configuration;

            SetRoutes(config);
            SetSerializerSettings(config);
        }

        private void SetRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("Features", "myapi/features", new { action = "Get", controller = "Feature" });
            config.Routes.MapHttpRoute("Default route", "myapi/{controller}", new { action = "Get" });
        }

        private void SetSerializerSettings(HttpConfiguration config)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { ContractResolver = new DefaultContractResolver() };
            config.Formatters.JsonFormatter.SerializerSettings = settings;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.EnsureInitialized();
        }
    }
}