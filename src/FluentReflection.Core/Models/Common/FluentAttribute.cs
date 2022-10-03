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

        public bool Is<T>(Func<T, bool>? filter = null) where T : Attribute
        {
            if (filter == null)
                return Name == typeof(T).Name;

            return _instance is T t && filter(t);
        }

        public T? As<T>() where T : Attribute
        {
            return _instance as T;
        }
    }
}
