using FluentReflection.Abstraction.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentReflection.Abstraction.Interfaces
{
    public interface IFluentModifier
    {
        Modifier Modifiers { get; }
    }
}
