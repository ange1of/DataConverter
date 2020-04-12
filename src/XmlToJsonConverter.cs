using System;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

namespace project {

    public class XmlToJsonConverter : DataConverter {
        public override void convert(string sourcePath, string targetPath) {
            string fullSourcePath = Path.GetFullPath(sourcePath);
            string fullTargetPath = Path.GetFullPath(targetPath);

            Console.WriteLine(fullSourcePath);
            Console.WriteLine(fullTargetPath);

            if (!File.Exists(fullSourcePath)) {
                Console.WriteLine($"Provided file {fullSourcePath} does not exist");
                return;
            }
            
            try {
                string json;
                using (StreamReader sr = new StreamReader(fullSourcePath)) {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(sr.ReadToEnd());

                    json = JsonConvert.SerializeXmlNode(xmlDocument);
                }

                if (!Directory.Exists(Path.GetDirectoryName(fullTargetPath))) {
                    Directory.CreateDirectory(Path.GetDirectoryName(fullTargetPath));
                }
                
                using (StreamWriter sw = new StreamWriter(fullTargetPath)) {
                    sw.Write(json);
                }
                
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        public override string convert(string xmlString) {
            try {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xmlString);

                return JsonConvert.SerializeXmlNode(xmlDocument);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            return "";
        }
    }
}