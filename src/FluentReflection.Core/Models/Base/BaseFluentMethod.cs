using FluentReflection.Abstraction.Interfaces;
using FluentReflection.Core.Models.Common;
using FluentReflection.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FluentReflection.Core.Models.Base
{
    internal abstract class BaseFluentMethod : BaseElement, IFluentMethod
    {
        internal readonly MethodInfo _methodInfo;

        public BaseFluentMethod(MethodInfo methodInfo, CacheUtility? cacheUtility = null) : base(cacheUtility)
        {
            _methodInfo = methodInfo;
        }
        public string Name => _methodInfo.Name;
        public IFluentType ReturnType => new FluentType(_methodInfo.ReturnType);
        public List<IFluentParameter> Parameters => _cacheUtility.Value(GetParameters);
        public abstract object Invoke(params object[] parameters);
        public abstract Task<object> InvokeAsync(params object[] parameters);

        internal override MemberInfo MemberInfo => _methodInfo;

        private List<IFluentParameter> GetParameters()
        {
            var parameters = _methodInfo.GetParameters();
            return parameters.Select(param => new FluentParameter(param, _cacheUtility)).Cast<IFluentParameter>().ToList();
        }
    }
}
