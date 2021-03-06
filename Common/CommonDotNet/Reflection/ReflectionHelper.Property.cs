﻿using System;
using System.Reflection;

namespace Common.Reflection
{
    public static partial class ReflectionHelper
    {
        /// <summary>
        /// 获取指定对象的属性的值。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <param name="propertyName">属性的名字。</param>
        /// <param name="option">属性名称的匹配方式。</param>
        /// <returns>属性的值。</returns>
        public static object GetProperty(object obj, string propertyName, SearchOption option = SearchOption.Default)
        {
            PropertyInfo property;
            if (HasProperty(obj, propertyName, out property, option) == true)
            {
                return property.GetValue(obj, null);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取指定对象的属性的值。
        /// </summary>
        /// <typeparam name="T">属性的类型。</typeparam>
        /// <param name="obj">对象。</param>
        /// <param name="propertyName">属性的名字。</param>
        /// <param name="option">属性名称的匹配方式。</param>
        /// <returns>属性的值。</returns>
        public static T GetProperty<T>(object obj, string propertyName, SearchOption option = SearchOption.Default)
        {
            return (T)GetProperty(obj, propertyName, option);
        }

        /// <summary>
        /// 指示指定对象是否有指定属性。
        /// </summary>
        /// <param name="obj">检查的对象。</param>
        /// <param name="propertyName">属性的名字。</param>
        /// <param name="option">属性名称的匹配方式。</param>
        /// <returns>是否具有属性。</returns>
        public static bool HasProperty(object obj, string propertyName, SearchOption option = SearchOption.Default)
        {
            PropertyInfo property;
            return HasProperty(obj, propertyName, out property, option);
        }

        /// <summary>
        /// 指示指定对象是否具有指定属性。
        /// </summary>
        /// <param name="obj">检查的对象。</param>
        /// <param name="propertyName">属性的名字。</param>
        /// <param name="property">属性。</param>
        /// <param name="option">属性名称的匹配方式。</param>
        /// <returns>是否具有属性。</returns>
        public static bool HasProperty(object obj, string propertyName, out PropertyInfo property, SearchOption option = SearchOption.Default)
        {
            Type t = obj.GetType();
            BindingFlags flags = (BindingFlags)0;
            if (option == SearchOption.IgnoreCase)
            {
                flags = flags | BindingFlags.IgnoreCase;
            }
            property = t.GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | flags);
            return property != null;
        }

        /// <summary>
        /// 设置指定对象的属性的值。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <param name="propertyName">属性的名字。</param>
        /// <param name="value">属性的值。</param>
        /// <param name="option">属性名称的匹配方式。</param>
        /// <returns>是否设置成功。</returns>
        public static bool SetProperty(object obj, string propertyName, object value, SearchOption option = SearchOption.Default)
        {
            PropertyInfo property;
            if (HasProperty(obj, propertyName, out property, option) == true)
            {
                if (property.CanWrite == true)
                {
                    property.SetValue(obj, value, null);
                    return true;
                }
            }
            return false;
        }
    }
}
