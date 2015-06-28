using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using AOEChat.Server.Core.Data;
using AOEChat.Server.Core.Infrastructure;
using Serilog;
using System.Configuration;

namespace AOEChat.Server.Core.Modules
{
    public class BusinessLogicModule : Module
    {
         protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var logFilePath = ConfigurationManager.AppSettings["LogFilePath"];

            builder.Register(o => new ConfigurationSettingsProvider()).As<IConfigurationSettingsProvider>();

            builder.Register(c => new LoggerConfiguration()
                .WriteTo.File(logFilePath)
                .CreateLogger()).
                As<ILogger>().SingleInstance();


            //builder.Register(c => new LoggerConfiguration()
            //.Enrich.With(new HttpRequestIdEnricher())
            //    //.WriteTo.Seq("http://localhost:60444/now")
            //    //.WriteTo.RollingFile(@"c:\Logs\Log-{Date}.txt")
            //    .WriteTo.MSSqlServer(@"Server=BLACKLAPDEV\SQLEXPRESS;Database=Sample;Trusted_Connection=True;", "Logs")
            //    .WriteTo.File(@"c:\Logs\Log-{Date}.txt")
            //    .CreateLogger()).
            //    As<ILogger>().SingleInstance();

            //builder.Register(o => new FileManager(o.Resolve<ILogger>())).As<IFileManager>();
            //builder.RegisterType<FileManagerService>().As<IFileManagerService>();



        }



    }

    

}
