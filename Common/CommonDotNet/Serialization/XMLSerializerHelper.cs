﻿using System.IO;
using System.Xml.Serialization;

namespace Common.Serialization
{
    /// <summary>
    /// 将对象序列化到 XML 文档中和从 XML 文档中反序列化对象。
    /// </summary>
    public static partial class XMLSerializerHelper
    {
        /// <summary>
        /// 将当前对象 XML 序列化到内存流中。
        /// </summary>
        /// <typeparam name="T">序列化的对象的类型。</typeparam>
        /// <param name="obj">序列化的对象。</param>
        /// <returns>序列化的 XML 内存流。</returns>
        public static MemoryStream SerializeToXMLStream<T>(this T obj)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            xs.Serialize(ms, obj);
            return ms;
        }

        /// <summary>
        /// 将指定的 XML 流反序列化为 T 类型的对象。
        /// </summary>
        /// <typeparam name="T">所生成对象的类型。</typeparam>
        /// <param name="input">要进行反序列化的 XML 流。</param>
        /// <returns>反序列化的对象。</returns>
        public static T Deserialize<T>(Stream input)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            return (T)xs.Deserialize(input);
        }

        /// <summary>
        /// 将当前对象以 XML 格式保存在文件中。
        /// </summary>
        /// <typeparam name="T">序列化的对象的类型。</typeparam>
        /// <param name="obj">序列化的对象。</param>
        /// <param name="filePath">文件路径。</param>
        public static void SerializeToXMLFile<T>(this T obj, string filePath)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            xs.Serialize(File.Create(filePath), obj);
        }

        /// <summary>
        /// 将指定的 XML 文件反序列化为 T 类型的对象。
        /// </summary>
        /// <typeparam name="T">所生成对象的类型。</typeparam>
        /// <param name="filePath">文件路径。</param>
        /// <returns>反序列化的对象。</returns>
        public static T Deserialize<T>(string filePath)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            return (T)xs.Deserialize(File.OpenRead(filePath));
        }
    }
}
