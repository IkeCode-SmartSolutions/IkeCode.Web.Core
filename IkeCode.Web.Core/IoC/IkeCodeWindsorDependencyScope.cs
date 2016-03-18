﻿namespace IkeCode.Web.Core.IoC
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Dependencies;
    using Castle.MicroKernel.Lifestyle;
    using Castle.MicroKernel;

    public class IkeCodeWindsorDependencyScope : IDependencyScope
    {
        private readonly IKernel kernel;

        private readonly IDisposable disposable;

        public IkeCodeWindsorDependencyScope(IKernel kernel)
        {
            this.kernel = kernel;
            disposable = kernel.BeginScope();
        }

        public object GetService(Type type)
        {
            return kernel.HasComponent(type) ? kernel.Resolve(type) : null;
        }

        public IEnumerable<object> GetServices(Type type)
        {
            return kernel.ResolveAll(type).Cast<object>();
        }

        public void Dispose()
        {
            disposable.Dispose();
        }
    }
}
