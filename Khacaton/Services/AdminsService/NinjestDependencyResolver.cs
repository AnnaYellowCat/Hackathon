using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Khacaton.Services.AdminsService
{
    public class NinjestDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjestDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public void AddBindings()
        {
            kernel.Bind<IAuthProvider>().To<FormAuthProvider>();
        }
        public object GetService(Type serviceType)
        {
            return kernel.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private static void RegisterService(IKernel kernel)
        {
            kernel.Bind<IAuthProvider>().To<FormAuthProvider>();
            DependencyResolver.SetResolver(new NinjestDependencyResolver(kernel));
        }
    }
}