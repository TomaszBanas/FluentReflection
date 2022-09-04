using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace FluentReflection.Core.Utils
{
    internal class CacheUtility
    {
        internal static CacheUtility Instance = new CacheUtility();

        private ConcurrentDictionary<long, ICacheItem> _cache = new ConcurrentDictionary<long, ICacheItem>();

        public T Value<T>(Func<T> action) where T : class
        {
            long hashCode = action.GetHashCode();
            if (!_cache.ContainsKey(hashCode))
            {
                Register(hashCode, action);
            }

            var value = _cache[hashCode].GetValue<T>();
            return value != null ? value : default;
        }

        private void Register<T>(long hashCode, Func<T> action) where T : class
        {
            if (_cache.ContainsKey(hashCode))
            {
                throw new InvalidOperationException("Method already registered");
            }

            _cache.TryAdd(hashCode, new CacheItem<T>(action));
        }
    }

    internal interface ICacheItem
    {
        T? GetValue<T>() where T : class;
    }

    internal class CacheItem<T> : ICacheItem where T : class
    {
        public DateTime? LastExecutionTime { get; set; }
        public Func<T> Action { get; set; }
        public T? Result { get; set; }

        public CacheItem(Func<T> action)
        {
            Action = action;
        }

        public T1? GetValue<T1>() where T1 : class
        {
            if(typeof(T) != typeof(T1))
            {
                throw new ArgumentException("add some message");
            }

            if(Result == null)
            {
                Result = Action() as T;
            }
            return Result as T1;
        }
    }
}
