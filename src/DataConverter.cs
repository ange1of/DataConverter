using System;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace project {

    public abstract class DataConverter {
        public abstract void convert(string sourcePath, string targetPath);

        public static void dumpObjectToJsonFile(Object obj, string targetFilePath) {
            string fullTargetFilePath = Path.GetFullPath(targetFilePath);
            if (!Directory.Exists(Path.GetDirectoryName(fullTargetFilePath))) {
                try {
                    Directory.CreateDirectory(Path.GetDirectoryName(fullTargetFilePath));
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            using (StreamWriter sw = new StreamWriter(fullTargetFilePath)) {
                try {
                    sw.Write(JsonConvert.SerializeObject(obj));
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
            
        }

        public static void dumpObjectToXmlFile(Object obj, string targetFilePath) {
            string fullTargetFilePath = Path.GetFullPath(targetFilePath);
            if (!Directory.Exists(Path.GetDirectoryName(fullTargetFilePath))) {
                try {
                    Directory.CreateDirectory(Path.GetDirectoryName(fullTargetFilePath));
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            using (StreamWriter sw = new StreamWriter(fullTargetFilePath)) {
                try {
                    XmlSerializer serializer = new XmlSerializer(obj.GetType());
                    serializer.Serialize(sw, obj);
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }

}