using Microsoft.Owin;
using Owin;
using System.IO;
using System.Web.Http;

[assembly: OwinStartup(typeof(RabbitMqTest.Startup))]
namespace RabbitMqTest
{
    public class Startup
    {
        HttpConfiguration config = new HttpConfiguration();

        public HttpConfiguration Config
        {
            get { return config; }
        }

        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
            new MqHelper().Register();
            //加载日志的配置文件
            log4net.Config.XmlConfigurator.Configure(new FileInfo("Log4net.xml"));
        }
    }
}