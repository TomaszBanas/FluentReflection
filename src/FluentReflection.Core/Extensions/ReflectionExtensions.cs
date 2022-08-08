using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using FluentReflection.Core.Models;
using FluentReflection.Abstraction;

namespace FluentReflection.Core.Extensions
{
    public static class ReflectionExtensions
    {
        public static IFluentReflection AsFluentReflection<T>(this T model) where T : class
        {
            return new FluentReflectionImplementation<T>(model);
        }
    }
}
