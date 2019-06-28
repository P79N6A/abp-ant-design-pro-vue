using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Niue.Common
{
	public sealed class XmlHelper
	{
        public static string ObjectToXml<T>(T t)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            var memoryStream = new MemoryStream();
            var xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            var xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add("", "");
            xmlSerializer.Serialize(xmlTextWriter, t, xmlSerializerNamespaces);
            xmlTextWriter.Close();
            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }

        public static T XmlToObject<T>(string xml)
        {
            var xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.LoadXml(xml);
                // ReSharper disable once AssignNullToNotNullAttribute
                var xmlNodeReader = new XmlNodeReader(xmlDocument.DocumentElement);
                var xmlSerializer = new XmlSerializer(typeof(T));
                var deserialize = xmlSerializer.Deserialize(xmlNodeReader);
                return (T)deserialize;
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        /// <summary>
        /// 微信XML转对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T WxXmlToObject<T>(string xml) where T : new()
        {
            var xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.LoadXml(xml);
                var t = new T();
                var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                // ReSharper disable once PossibleNullReferenceException
                foreach (var propertyInfo in propertyInfos)
                {
                    XmlNode xmlElement = xmlDocument.DocumentElement[propertyInfo.Name];

                    propertyInfo.SetValue(t, xmlElement?.InnerText);
                }
                return t;
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        /// <summary>
        /// 微信对象转XML
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string WxObjectToXml<T>(T t)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<xml>");
            var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).OrderBy(o => o.Name);
            foreach (var propertyInfo in propertyInfos)
            {
                var value = propertyInfo.GetValue(t, null)?.ToString();
                if (string.IsNullOrWhiteSpace(value))
                {
                    continue;
                }
                stringBuilder.Append("<" + propertyInfo.Name + "><![CDATA[" + value + "]]></" + propertyInfo.Name + ">");
            }
            stringBuilder.Append("</xml>");
            return stringBuilder.ToString();
        }
    }
}
