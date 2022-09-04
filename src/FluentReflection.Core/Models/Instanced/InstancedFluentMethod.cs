using FluentReflection.Core.Models.Base;
using FluentReflection.Core.Utils;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FluentReflection.Core.Models.Instanced
{
    internal class InstancedFluentMethod<T> : BaseFluentMethod where T : class
    {
        private readonly T _instance;

        public InstancedFluentMethod(MethodInfo methodInfo, T instance, CacheUtility? cacheUtility = null) : base(methodInfo, cacheUtility)
        {
            _instance = instance;
        }

        public override object Invoke(params object[] parameters)
        {
            return _methodInfo.Invoke(_instance, parameters);
        }

        public override async Task<object> InvokeAsync(params object[] parameters)
        {
            return await (dynamic)_methodInfo.Invoke(_instance, parameters);
        }
    }
}
