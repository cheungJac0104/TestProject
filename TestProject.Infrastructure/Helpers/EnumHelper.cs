using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace TestProject.Infrastructure.Helpers
{
    public static class EnumHelper
    {
        public static void InitEnumResourceManager(ResourceManager rm)
        {
            EnumItemsCache.InitEnumResourceManager(rm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumField"></param>
        /// <returns></returns>
        public static string GetEnumDescription(Enum enumField)
        {
            return GetEnumItem(enumField).Description;
        }

        /// <summary>
        /// 根据枚举值返回描述，未找到则返回指定Default值的描述
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetEnumDescription<T>(int value, T defaultValue)
        {
            string enumKey = EnumHelper.GetEnumByValue<T>(value, defaultValue).ToString();
            EnumItemCollection enumItems = GetEnumItems(typeof(T));
            return enumItems.Contains(enumKey) ? enumItems[enumKey].Description : enumKey.ToString();
        }

        public static string GetEnumDescription<T>(this T enumValue)
        {
            string enumKey = enumValue.ToString();
            EnumItemCollection enumItems = GetEnumItems(typeof(T));
            return enumItems.Contains(enumKey) ? enumItems[enumKey].Description : enumKey.ToString();
        }

        /// <summary>
        /// 根据枚举值返回描述，未找到则返回Empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetEnumDescription<T>(int value)
        {
            string enumKey = EnumHelper.GetEnumByValue<T>(value, default(T)).ToString();
            EnumItemCollection enumItems = GetEnumItems(typeof(T));
            return enumItems.Contains(enumKey) ? enumItems[enumKey].Description : enumKey.ToString();
        }

        public static T GetEnumObject<T>(string text)
        {
            return (T)Enum.Parse(typeof(T), text, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumField"></param>
        /// <returns></returns>
        public static EnumItem GetEnumItem<T>(T enumField)
        {
            EnumItemCollection enumItems = GetEnumItems(typeof(T));
            return enumItems[enumField.ToString()];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumField"></param>
        /// <returns></returns>
        public static EnumItem GetEnumItem(Enum enumField)
        {
            EnumItemCollection enumItems = GetEnumItems(enumField.GetType());
            return enumItems[enumField.ToString()];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static EnumItemCollection GetEnumItems(Type enumType)
        {
            return EnumItemsCache.GetNoCache(enumType);
        }
        /// <summary>
        /// 获取所有枚举项
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static EnumItemCollection GetEnumItems<TEnum>() where TEnum : struct
        {
            return EnumItemsCache.GetNoCache(typeof(TEnum));
        }
        /// <summary>
        /// 获取所有枚举项并附带一个请选择
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static EnumItemCollection GetEnumItemsAddSelectItem<TEnum>() where TEnum : struct
        {
            var data = EnumItemsCache.GetNoCache(typeof(TEnum)) ?? new EnumItemCollection();
            data.Insert(0, new EnumItem("none", -999, "请选择"));
            return data;
        }

        public static EnumItemCollection GetEnumItemsAddAllItem<TEnum>() where TEnum : struct
        {
            var data = EnumItemsCache.GetNoCache(typeof(TEnum)) ?? new EnumItemCollection();
            data.Insert(0, new EnumItem("none", -999, "全部"));
            return data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetEnumByKey<T>(string key)
        {
            return GetEnumByKey<T>(key, default(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T GetEnumByKey<T>(string key, T defaultValue)
        {
            T item = defaultValue;
            EnumItem enumItem = null;
            try
            {
                Type enumType = typeof(T);
                EnumItemCollection enumItems = EnumItemsCache.Get(enumType);
                enumItems.TryGet(key, out enumItem);
                if (enumItem != null)
                {
                    item = (T)Enum.ToObject(enumType, enumItem.Value);
                }
            }
            catch
            {
                item = defaultValue;
            }
            return item;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T GetEnumByValue<T>(int value)
        {
            return GetEnumByValue<T>(value, default(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T GetEnumByValue<T>(int value, T defaultValue)
        {
            T item = defaultValue;
            try
            {
                EnumItemCollection enumItems = GetEnumItems(typeof(T));
                foreach (EnumItem enumItem in enumItems)
                {
                    if (enumItem.Value == value)
                    {
                        item = (T)Enum.ToObject(typeof(T), enumItem.Value);
                    }
                }
            }
            catch
            {
                item = defaultValue;
            }
            return item;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T GetEnumByValue<T>(string value)
        {
            return GetEnumByValue<T>(value, default(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T GetEnumByValue<T>(string value, T defaultValue)
        {
            T item = defaultValue;
            try
            {
                EnumItemCollection enumItems = GetEnumItems(typeof(T));
                foreach (EnumItem enumItem in enumItems)
                {
                    if (enumItem.Value.ToString() == value)
                    {
                        item = (T)Enum.ToObject(typeof(T), enumItem.Value);
                    }
                }
            }
            catch
            {
                item = defaultValue;
            }
            return item;
        }

        /// <summary>
        /// get the Enum value according to the its decription
        /// </summary>
        /// <typeparam name="T">the type of the enum</typeparam>
        /// <param name="description">the description of the EnumValue</param>
        /// <returns></returns>
        public static T GetEnumByDescription<T>(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                return default(T);
            }

            Type enumType = typeof(T);
            EnumItemCollection list = GetEnumItems(enumType);
            foreach (EnumItem item in list)
            {
                if (item.Description.ToString().ToLower() == description.Trim().ToLower())
                {
                    return (T)Enum.ToObject(typeof(T), item.Value);
                }
            }
            return default(T);
        }

        public static string GetJsonEnum(Type enumType)
        {
            return GetJsonEnum(enumType, null);
        }

        public static string GetJsonEnum(Type enumType, string alias)
        {
            int[] values = (int[])Enum.GetValues(enumType);
            string[] names = Enum.GetNames(enumType);
            string[] pairs = new string[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                pairs[i] = names[i] + ": " + values[i];
            }

            if (string.IsNullOrEmpty(alias))
                alias = enumType.Name;

            return string.Format("var {0}={{{1}}}", alias, string.Join(",", pairs));
        }
    }

    /// <summary>
    /// RelationShip between Key and Value
    /// </summary>
    [Serializable]
    public class EnumItem
    {
        private string _key;
        private int _value;
        private string _description;


        /// <summary>
        /// Enum Key
        /// </summary>
        public string Key
        {
            get { return _key; }
        }

        /// <summary>
        /// Enum Value
        /// </summary>
        public int Value
        {
            get { return _value; }
        }

        /// <summary>
        /// Enum Description
        /// </summary>
        public string Description
        {
            get { return _description; }
        }
        public EnumItem()
        {
        }

        /// <summary>
        /// Custructor
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public EnumItem(string key, int value)
            : this(key, value, key)
        {
        }

        /// <summary>
        /// Custructor
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public EnumItem(string key, int value, string description)
        {
            _key = key;
            _value = value;
            _description = description;
        }
    }
    [Serializable]
    public class EnumItemCollection : KeyedCollection<string, EnumItem>
    {
        protected override string GetKeyForItem(EnumItem item)
        {
            return item.Key;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="enumItem"></param>
        /// <returns></returns>
        public bool TryGet(string key, out EnumItem enumItem)
        {
            enumItem = null;
            if (this.Contains(key))
            {
                enumItem = this[key];
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsKeyExist(string key)
        {
            bool isExists = false;
            foreach (EnumItem enumItem in this)
            {
                if (key == enumItem.Key)
                    isExists = true;
            }
            return isExists;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal class EnumItemsCache
    {
        private static readonly Regex CamelRegex = new Regex(@"(?<=\w)[A-Z](?=[a-z0-9])|(?<=[a-z0-9])[A-Z]|\d");
        private static Dictionary<string, EnumItemCollection> _typedEnumItemsCache
            = new Dictionary<string, EnumItemCollection>();
        private static object _syncObj = new object();
        private static ResourceManager _enumResourceManager;

        public static void InitEnumResourceManager(ResourceManager rm)
        {
            if (_enumResourceManager == null)
            {
                lock (_syncObj)
                {
                    if (_enumResourceManager == null)
                    {
                        _enumResourceManager = rm;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static EnumItemCollection Get(Type enumType)
        {
            EnumItemCollection enumItems = null;
            string cacheKey;
            if (_enumResourceManager != null)
            {
                cacheKey = enumType.FullName + "_" + Thread.CurrentThread.CurrentCulture.Name;
            }
            else
            {
                cacheKey = enumType.FullName;
            }
            if (!_typedEnumItemsCache.TryGetValue(cacheKey, out enumItems))
            {
                enumItems = GetEnumItems(enumType);
                Add(cacheKey, enumItems);
            }

            return enumItems;
        }

        public static EnumItemCollection GetNoCache(Type enumType)
        {
            EnumItemCollection enumItems = null;
            string cacheKey;
            if (_enumResourceManager != null)
            {
                cacheKey = enumType.FullName + "_" + Thread.CurrentThread.CurrentCulture.Name;
            }
            else
            {
                cacheKey = enumType.FullName;
            }
            enumItems = GetEnumItems(enumType);
            return enumItems;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="enumItems"></param>
        private static void Add(string cacheKey, EnumItemCollection enumItems)
        {
            if (!_typedEnumItemsCache.ContainsKey(cacheKey))
            {
                lock (_syncObj)
                {
                    if (!_typedEnumItemsCache.ContainsKey(cacheKey))
                    {
                        _typedEnumItemsCache.Add(cacheKey, enumItems);
                    }
                }
            }
        }

        /// <summary>
        /// get the enum's all list
        /// </summary>
        /// <param name="enumType">the type of the enum</param>
        /// <param name="withAll">identicate whether the returned list should contain the all item</param>
        /// <returns></returns>
        private static EnumItemCollection GetEnumItems(Type enumType)
        {
            EnumItemCollection emumItems = new EnumItemCollection();

            if (enumType.IsEnum != true)
            {
                // just whethe the type is enum type
                throw new InvalidOperationException();
            }

            // 获得特性Description的类型信息
            Type typeDescription = typeof(DescriptionAttribute);

            // 获得枚举的字段信息（因为枚举的值实际上是一个static的字段的值）
            FieldInfo[] fields = enumType.GetFields();

            // 检索所有字段
            foreach (FieldInfo field in fields)
            {
                // 过滤掉一个不是枚举值的，记录的是枚举的源类型
                if (field.FieldType.IsEnum == false)
                {
                    continue;
                }

                // 通过字段的名字得到枚举的值
                int value = (int)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null);
                string description = string.Empty;

                //在多语言环境下,从资源文件中读取
                if (_enumResourceManager != null)
                {
                    description = _enumResourceManager.GetString(string.Format("{0}_{1}", enumType.Name, field.Name));
                }
                else
                {
                    // 获得这个字段的所有自定义特性，这里只查找Description特性
                    object[] arr = field.GetCustomAttributes(typeDescription, true);
                    if (arr.Length > 0)
                    {
                        // 因为Description自定义特性不允许重复，所以只取第一个
                        DescriptionAttribute descriptionAttri = (DescriptionAttribute)arr[0];

                        // 获得特性的描述值
                        description = descriptionAttri.Description;
                    }
                }

                if (string.IsNullOrWhiteSpace(description))
                {
                    // 如果没有特性描述，那么就显示英文的字段名 按Camel写法分隔
                    description = CamelRegex.Replace(field.Name, " $0");
                }
                emumItems.Add(new EnumItem(field.Name, value, description));
            }

            return emumItems;
        }
    }
}
