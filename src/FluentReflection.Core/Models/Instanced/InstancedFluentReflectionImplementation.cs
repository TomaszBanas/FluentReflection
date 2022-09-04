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

namespace FluentReflection.Core.Models.Instanced
{
    internal class InstancedFluentReflectionImplementation<T> : BaseFluentReflectionImplementation where T : class
    {
        private readonly T _instance;

        internal InstancedFluentReflectionImplementation(T instance, CacheUtility? cacheUtility = null) : base(typeof(T), cacheUtility)
        {
            _instance = instance;
        }

        internal override List<IFluentProperty> GetProperties()
        {
            var properties = _type.GetProperties();
            return properties.Select(property => new InstancedFluentProperty<T>(property, _instance, _cacheUtility)).Cast<IFluentProperty>().ToList();
        }

        internal override List<IFluentMethod> GetMethods()
        {
            var methods = _type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).Where(x => !x.CustomAttributes.Any(x => x.AttributeType == typeof(CompilerGeneratedAttribute)));
            return methods.Select(method => new InstancedFluentMethod<T>(method, _instance, _cacheUtility)).Cast<IFluentMethod>().ToList();
        }
    }
}
