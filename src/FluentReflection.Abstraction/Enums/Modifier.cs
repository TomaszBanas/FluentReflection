using System;
using System.Collections.Generic;
using System.Text;

namespace FluentReflection.Abstraction.Enums
{
    public enum Modifier
    {
        None = 0,
        Public = 1,
        Private = 2,
        Protected = 4,
        Static = 8,
        Const = 16,
        Readonly = 32,
        Async = 64,
        Virtual = 128,
        Abstract = 256,
        Internal = 512,
        Sealed = 1024,
        Constructor = 2048,
    }
}
