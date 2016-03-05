using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponera.Base.DependencyInjection.Bootstrapper.Base
{
    public interface IRegisterModuleOrComponent : IRegisterModule
    {
        void Load();

        IRegisterModuleOrComponent Register(Action<ContainerBuilderAdapter> registerAction);
    }

    public interface IRegisterModule
    {
        IRegisterModuleOrComponent RegisterModule<T>() where T : BaseModule, new();
    }
}
