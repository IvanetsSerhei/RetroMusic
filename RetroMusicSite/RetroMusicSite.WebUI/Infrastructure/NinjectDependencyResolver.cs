using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using RetroMusicSite.Domain.Abstract;
using RetroMusicSite.Domain.Concrete;

namespace RetroMusicSite.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
           return  _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            _kernel.Bind<IRepository>().To<EfRepository>();
        }
    }
}