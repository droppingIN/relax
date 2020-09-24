using System.Collections.Generic;

namespace com.on.relax.your.eyes.logic
{
    using IProperties = IDictionary<string, object>;
    public static class PropertiesExtension
    {
        public static T Get<T>(this IProperties props, string key, T initial)
        {
            T result = initial;
            if (props.ContainsKey(key))
                result = (T)props[key];
            return result;
        }

        public static void Set(this IProperties props, string key, object value)
        {
            props[key] = value;
        }
    }
}
