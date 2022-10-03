using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using FluentReflection.Core.Models;
using FluentReflection.Abstraction;
using FluentReflection.Core.Utils;
using FluentReflection.Core.Models.Instanced;
using FluentReflection.Core.Models.Class;

namespace FluentReflection.Core.Extensions
{
    public static class ReflectionExtensions
    {
        public static IFluentReflection AsReflection<T>(this T @this) where T : class, new()
        {
            return new InstancedFluentReflectionImplementation<T>(@this, CacheUtility.Instance);
        }

        public static IFluentReflection Reflect(Type type)
        {
            return new ClassFluentReflectionImplementation(type, CacheUtility.Instance);
        }

        public static IFluentReflection Reflect(Assembly assembly)
        {
            return null;
            //return new StaticFluentReflectionImplementation(type, CacheUtility.Instance);
        }
    }
}
