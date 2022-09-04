using FluentReflection.Core.Models.Base;
using FluentReflection.Core.Utils;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FluentReflection.Core.Models.Static
{
    internal class StaticFluentMethod : BaseFluentMethod
    {
        public StaticFluentMethod(MethodInfo methodInfo, CacheUtility? cacheUtility = null) : base(methodInfo, cacheUtility) { }

        public override object Invoke(params object[] parameters)
        {
            return _methodInfo.Invoke(null, parameters);
        }

        public override async Task<object> InvokeAsync(params object[] parameters)
        {
            return await (dynamic)_methodInfo.Invoke(null, parameters);
        }
    }
}
