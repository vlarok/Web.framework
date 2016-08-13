using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StructureMap;

namespace Web.framework.Infrastructure
{
    public class StruructureMapDependencyResolver:IDependencyResolver
    {
        readonly Container container = new Container();
        public object GetService(Type serviceType)
        {
           
            container.Configure(cfg =>
            {
                cfg.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
            });
            return serviceType.IsAbstract || serviceType.IsInterface ?
                container.TryGetInstance(serviceType) :
                container.GetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {

            return container.GetAllInstances(serviceType).Cast<object>();
        }
    }
}