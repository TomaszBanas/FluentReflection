using System;
using System.Collections.Generic;
using System.Text;

namespace FluentReflection.Abstraction.Interfaces
{
    public interface IFluentParameter : IFluentElement// TODO: implement class IFluentParameter
    {
        Type Type { get; }
    }
}
