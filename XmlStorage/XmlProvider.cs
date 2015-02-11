using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace XmlStorage
{
    public class XmlProvider
    {
        public static void SaveStorage<T>(T entityCollection, string path)
        {
            using (var filestream = new FileStream(path, FileMode.Create))
            {
                var settings = new XmlWriterSettings { Encoding = System.Text.Encoding.UTF8, Indent = true };
                using (var writer = XmlTextWriter.Create(filestream, settings))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(writer, entityCollection);
                }
            }
        }

        public static T LoadStorage<T>(string path) where T : new()
        {
            if (File.Exists(path))
            {
                using (var stream = new StreamReader(path))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    try
                    {
                        return (T)serializer.Deserialize(stream);
                    }
                    catch (InvalidOperationException)
                    {
                        stream.Close();
                    }
                }
            }
            return GetNewStorage<T>(path);
        }

        private static T GetNewStorage<T>(string path) where T : new()
        {
            var entities = new T();
            SaveStorage(entities, path);
            return entities;
        }
    }
}
