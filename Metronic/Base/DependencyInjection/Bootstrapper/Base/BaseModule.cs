using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Ponera.Base.DependencyInjection.Bootstrapper.Base
{
    public abstract class BaseModule : Autofac.Module
    {
        public abstract void OnBuildComplete(IContainer container);

        public abstract void OnLoad(ContainerBuilder builder);

        // Todo : complate logic on Bootstrapper
        public abstract void OnPreLoad();

        protected sealed override void Load(ContainerBuilder builder)
        {
            OnLoad(builder);
            base.Load(builder);
        }
    }
}
