using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using FluentReflection.Core.Models;
using FluentReflection.Abstraction;
using FluentReflection.Core.Utils;
using FluentReflection.Core.Models.Instanced;
using FluentReflection.Core.Models.Static;

namespace FluentReflection.Core.Extensions
{
    public static class ReflectionExtensions
    {
        public static IFluentReflection AsFluentReflection<T>(this T @this) where T : class, new()
        {
            return new InstancedFluentReflectionImplementation<T>(@this, CacheUtility.Instance);
        }

        public static IFluentReflection AsFluentReflectionStatic(Type type)
        {

            return new StaticFluentReflectionImplementation(type, CacheUtility.Instance);
        }
    }
}
