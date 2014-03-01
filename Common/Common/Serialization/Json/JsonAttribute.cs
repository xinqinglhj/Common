﻿using System;

namespace Common.Serialization
{
    /// <summary>
    /// 标记字段或属性以自定义 JSON 序列化
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed partial class JsonAttribute : Attribute
    {
        public JsonAttribute()
        {
        }

        public JsonAttribute(string name)
        {
            Name = name;
        }

        public JsonAttribute(Type converter)
        {
            Converter = converter;
        }

        public JsonAttribute(string name, Type converter)
        {
            Name = name;
            Converter = converter;
        }

        /// <summary>
        /// 指定在序列化和反序列化时映射的名字。
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 是否在序列化时忽略标记的字段或属性。
        /// </summary>
        public bool Ignore
        {
            get;
            set;
        }

        /// <summary>
        /// 若标记的字段或属性为 null 时，是否在序列化时忽略。
        /// </summary>
        public bool IgnoreNull
        {
            get;
            set;
        }

        /// <summary>
        /// 使用自定义的序列化转换。
        /// </summary>
        public Type Converter
        {
            get;
            set;
        }

        /// <summary>
        /// 是否序列化与反序列化非公有字段或属性。
        /// </summary>
        public bool ProcessNonPublic
        {
            get;
            set;
        }
    }
}