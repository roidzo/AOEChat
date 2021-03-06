﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using AOEChat.Server.Core.Data;

namespace AOEChat.Server.Core.Modules
{
    public class DataServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType(typeof(DataServiceMessage))
                .As(typeof(IDataServiceMessage))
                .SingleInstance()
                ;

            builder.RegisterType(typeof(DataServiceDto))
               .As(typeof(IDataServiceDto))
               .SingleInstance()
               ;


        }
        
    }
}
