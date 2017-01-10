using ContactManager.Infrastructure;
using ContactManager.Models;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ContactManager.App_Start
{
    public class NinjectCommon
    {
        public static IKernel CreateKernel(HttpConfiguration config)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            AddBindings(kernel);

            config.DependencyResolver=new NinjectDependencyResolver(kernel);
            return kernel;
        }

        private static void AddBindings(IKernel kernel)
        {
            kernel.Bind<IContactRepository>().To<ContactRepository>();
        }
    }
}