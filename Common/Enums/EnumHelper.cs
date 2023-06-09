﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public static class EnumHelper<T>
    where T : struct, Enum // This constraint requires C# 7.3 or later.
    {
        //public static int GetId(this Enum value)
        //{
        //    if (value == null)
        //    {
        //        return 0;
        //    }

        //    var result = Convert.ChangeType(value, typeof(int));
        //    return (int)result;
        //}
        public static IList<T> GetValues(Enum value)
        {
            var enumValues = new List<T>();

            foreach (FieldInfo fi in value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                enumValues.Add((T)Enum.Parse(value.GetType(), fi.Name, false));
            }
            return enumValues;
        }

        public static T Parse(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static IList<string> GetNames(Enum value)
        {
            var _result = value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public).Select(fi => fi.Name).ToList();
            return _result;
        }

        public static IList<string> GetDisplayValues(Enum value)
        {
            var _result = GetNames(value).Select(obj => GetDisplayValue(Parse(obj))).ToList();
            return _result;
        }

        private static string lookupResource(Type resourceManagerProvider, string resourceKey)
        {
            foreach (PropertyInfo staticProperty in resourceManagerProvider.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
            {
                if (staticProperty.PropertyType == typeof(System.Resources.ResourceManager))
                {
                    System.Resources.ResourceManager resourceManager = (System.Resources.ResourceManager)staticProperty.GetValue(null, null);
                    return resourceManager.GetString(resourceKey);
                }
            }

            return resourceKey; // Fallback with the key name
        }

        public static string GetDisplayValue(T value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var descriptionAttributes = fieldInfo.GetCustomAttributes(
                typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            var _result = descriptionAttributes[0];
            if (descriptionAttributes[0] != null)
                return lookupResource(descriptionAttributes[0].GetType(), descriptionAttributes[0].Description);

            if (descriptionAttributes == null) return string.Empty;
            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : value.ToString();
        }

        public static IEnumerable<EnumDto> GetValueAndDescription()
        {
            var _result = Enum.GetValues(typeof(T))
                                                 .Cast<Enum>()
                                                 .Select(value => new EnumDto()
                                                 {
                                                     Id = (int)Convert.ChangeType(value, typeof(int)),
                                                     Description = GetDisplayValue(Parse(value.ToString())),
                                                     value = value.ToString()
                                                 })
                                                 .OrderBy(item => item.Id);

            //if (Request_value != null)
            //    _result = (IOrderedEnumerable<EnumDto>)_result.Where(x => x.value == Request_value);

            return _result.ToList();
        }
    }

    public class EnumDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string value { get; set; }
        public bool IsActive { get; set; } = false;
    }

    public class EnumDtoTypeMaterials
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string value { get; set; }
        public bool IsActive { get; set; } = false;
    }


}
