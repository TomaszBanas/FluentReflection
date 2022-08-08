using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentReflection.Abstraction.Interfaces
{
    public interface IFluentMethod : IFluentElement // TODO: implement class IFluentMethod
    {
        Type ReturnType { get; }
        IEnumerable<IFluentParameter> Parameters { get; }
        object Invoke(params object[] parameters);
        Task<object> InvokeAsync(params object[] parameters);
    }
}
