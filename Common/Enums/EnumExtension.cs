using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Common.Enums
{
    public static class EnumExtension
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum value)
            where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            if (name == null)
                return null;
            return type.GetField(name).GetCustomAttributes(false).OfType<TAttribute>().SingleOrDefault();
        }

        public static string GetPatternName(this Enum value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            var description = value.GetAttribute<Pattern>();
            return description?.PatternName;
        }

        public static string GetEnumDescription(this Enum value)
        {

            if (value == null)
            {
                return string.Empty;
            }

            var description = value.GetAttribute<DescriptionAttribute>();
            return description?.Description;
        }

        public static T? SafeNullableEnum2<T>(this int e) where T : struct
        {
            if (!Enum.IsDefined(typeof(T), e))
                return null;
            return (T)Enum.ToObject(typeof(T), e);
        }

        public static T? SafeNullableEnum2<T>(this int? e) where T : struct
        {
            if (!Enum.IsDefined(typeof(T), e))
                return null;
            return (T)Enum.ToObject(typeof(T), e);
        }

        public static int GetId(this Enum value)
        {
            if (value == null)
            {
                return 0;
            }

            var val = Convert.ChangeType(value, typeof(int));
            return val.SafeInt();
        }
        public static string GetName(this Enum value)
        {
            return value == null ? null : nameof(value);
        }

        public static string EnumListToString<T>(this List<T> value) where T : Enum
        {
            string result = "";
            foreach (var item in value)
            {
                var enumInt = item.GetId();
                result += enumInt.ToString();
            }

            return result;
        }

        public static List<T> ToEnumList<T>(this string value) where T : Enum
        {
            var result = new List<T>();

            foreach (var item in value)
            {
                var t = (T)Enum.Parse(typeof(T), item.ToString());
                result.Add(t);
            }

            return result;
        }
    }
}