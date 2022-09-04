using FluentReflection.Abstraction.Enums;
using FluentReflection.Abstraction.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentReflection.Core.Models.Common
{
    internal class FluentModifier : IFluentModifier
    {
        public Modifier Modifiers { get; set; }
    }
}
