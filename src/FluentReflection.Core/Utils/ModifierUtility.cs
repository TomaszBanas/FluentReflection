using FluentReflection.Abstraction.Enums;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FluentReflection.Core.Utils
{
    internal static class ModifierUtility
    {
        internal static Modifier ToModifiers(MemberInfo memberInfo)
        {
            if(memberInfo is Type type)
            {
                return ToModifiers(type);
            }

            if (memberInfo is MethodInfo methodInfo)
            {
                return ToModifiers(methodInfo);
            }

            if (memberInfo is PropertyInfo propertyInfo)
            {
                return ToModifiers(propertyInfo);
            }

            throw new NotImplementedException();
        }

        private static Modifier ToModifiers(Type type)
        {
            var result = Modifier.None;

            if (type.IsPublic)
            {
                result |= Modifier.Public;
            }

            if (type.IsNotPublic)
            {
                result |= Modifier.Internal;
            }

            if (type.IsAbstract && type.IsSealed)
            {
                result |= Modifier.Static;
            }
            else
            {
                if (type.IsAbstract)
                {
                    result |= Modifier.Abstract;
                }
            
                if (type.IsSealed)
                {
                    result |= Modifier.Sealed;
                }
            }

            return result;
        }

        private static Modifier ToModifiers(MethodInfo method)
        {
            var result = Modifier.None;
            if(method.IsPublic)
            {
                result |= Modifier.Public;
            }
            if(method.IsPrivate)
            {
                result |= Modifier.Private;
            }
            if (method.IsStatic)
            {
                result |= Modifier.Static;
            }
            if (method.ReturnType == typeof(Task))
            {
                result |= Modifier.Async;
            }
            if (method.IsVirtual)
            {
                result |= Modifier.Virtual;
            }
            if (method.IsAbstract)
            {
                result |= Modifier.Abstract;
            }
            if (!method.IsPublic && !method.IsPrivate)
            {
                result |= Modifier.Internal;
            }
            if (method.IsConstructor)
            {
                result |= Modifier.Constructor;
            }

            return result;
        }

        private static Modifier ToModifiers(PropertyInfo property)
        {
            if(property.CanRead)
            {

            }

            var result = Modifier.None;
            //if (property.IsPublic)
            //{
            //    result |= Modifier.Public;
            //}
            //if (property.IsPrivate)
            //{
            //    result |= Modifier.Private;
            //}
            //if (property.IsStatic)
            //{
            //    result |= Modifier.Static;
            //}
            //if (property.IsVirtual)
            //{
            //    result |= Modifier.Virtual;
            //}
            //if (property.IsAbstract)
            //{
            //    result |= Modifier.Abstract;
            //}
            //if (!property.IsPublic && !property.IsPrivate)
            //{
            //    result |= Modifier.Internal;
            //}
            //if (property.IsConstructor)
            //{
            //    result |= Modifier.Constructor;
            //}

            return result;
        }
    }
}
