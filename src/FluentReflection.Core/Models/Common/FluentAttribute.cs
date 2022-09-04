using FluentReflection.Abstraction.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentReflection.Core.Models
{
    internal class FluentAttribute : IFluentAttribute
    {
        private readonly Attribute _instance;
        public FluentAttribute(Attribute instance)
        {
            _instance = instance;
        }
        public string Name => _instance.GetType().Name;
        public Attribute GetInstance() => _instance;
    }
}
