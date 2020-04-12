using System;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;


namespace project {

    public class JsonToXmlConverter : DataConverter {
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
                XDocument xml;
                
                using (StreamReader sr = new StreamReader(fullSourcePath)) {
                    xml = XDocument.Parse(JsonConvert.DeserializeXmlNode(sr.ReadToEnd()).InnerXml);
                }

                if (!Directory.Exists(Path.GetDirectoryName(fullTargetPath))) {
                    Directory.CreateDirectory(Path.GetDirectoryName(fullTargetPath));
                }
                
                using (StreamWriter sw = new StreamWriter(fullTargetPath)) {
                    sw.Write(xml);
                }
                
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        public override string convert(string jsonString) {
            try {
                XDocument xml = XDocument.Parse(JsonConvert.DeserializeXmlNode(jsonString).InnerXml);
                return xml.ToString();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            return "";
        }
    }
}