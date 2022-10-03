using System;
using System.Collections.Generic;
using System.Text;

namespace FluentReflection.Abstraction.Interfaces
{
    public interface IFluentAttribute
    {
        string Name { get; }
        bool Is<T>(Func<T, bool>? filter = null) where T : Attribute;
        T? As<T>() where T : Attribute;
    }
}
