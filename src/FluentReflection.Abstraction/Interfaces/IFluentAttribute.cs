using System;
using System.Collections.Generic;
using System.Text;

namespace FluentReflection.Abstraction.Interfaces
{
    public interface IFluentAttribute
    {
        string Name { get; }
        Attribute GetInstance();
    }
}
