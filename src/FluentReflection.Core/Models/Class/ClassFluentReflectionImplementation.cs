using FluentReflection.Abstraction;
using FluentReflection.Abstraction.Enums;
using FluentReflection.Abstraction.Interfaces;
using FluentReflection.Core.Models.Base;
using FluentReflection.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace FluentReflection.Core.Models.Class
{
    internal class ClassFluentReflectionImplementation : BaseFluentReflectionImplementation
    {
        internal ClassFluentReflectionImplementation(Type type, CacheUtility? cacheUtility = null) : base(type, cacheUtility) { }

        internal override List<IFluentProperty> GetProperties()
        {
            var properties = _type.GetProperties();
            return properties.Select(property => new ClassFluentProperty(property, _cacheUtility)).Cast<IFluentProperty>().ToList();
        }
        internal override List<IFluentMethod> GetMethods()
        {
            var methods = _type.GetMethods(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public).Where(x => !x.CustomAttributes.Any(x => x.AttributeType == typeof(CompilerGeneratedAttribute)));
            return methods.Select(method => new ClassFluentMethod(method, _cacheUtility)).Cast<IFluentMethod>().ToList();
        }
    }
}
