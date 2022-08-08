using System;
using System.Collections.Generic;
using System.Text;

namespace FluentReflection.Abstraction.Interfaces
{
    public interface IFluentAttribute : IFluentElement // TODO: implement class IFluentAttribute
    {
        Type Type { get; }
        object Instance { get; }
    }
}
