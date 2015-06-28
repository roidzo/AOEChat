using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using AOEChat.Server.Core.Data;


namespace AOEChat.Server.Core.Modules
{
    public class RepositoryModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepository<>))
                //.As(typeof(IQueryableRepository<>))
                .InstancePerLifetimeScope()
                ;



        }
    }

}
