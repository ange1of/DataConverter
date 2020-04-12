using System;
using Xunit;
using project;
using System.IO;

namespace test
{
    public class JsonToXmlConverterTests {

        [Fact]
        public void testDataTypes() {
            TestUtils.WriteFile("jsontoxml.json", @"{""root"":{ ""field1"":""b"", ""field2"" : 33, ""field3"" : -22.5, ""field4"" : false }}");

            JsonToXmlConverter converter = new JsonToXmlConverter();
            converter.convert("jsontoxml.json", "jsontoxml.xml");

            Assert.Equal(@"<root><field1>b</field1><field2>33</field2><field3>-22.5</field3><field4>false</field4></root>", TestUtils.ReadFile("jsontoxml.xml").Replace("\r\n", "").Replace("  ", ""));
        }

        [Fact]
        public void testEmpty() {
            TestUtils.WriteFile("jsontoxml.json", @"{""root"": {}}");

            JsonToXmlConverter converter = new JsonToXmlConverter();
            converter.convert("jsontoxml.json", "jsontoxml.xml");

            Assert.Equal(@"<root />", TestUtils.ReadFile("jsontoxml.xml").Replace("\r\n", "").Replace("  ", ""));
        }

        [Fact]
        public void testCycleConvertation() {
            TestUtils.WriteFile("jsontoxml.json", @"{""root"":{ ""field1"":""b"", ""field2"" : 33, ""field3"" : -22.5, ""field4"" : false }}");

            JsonToXmlConverter converter = new JsonToXmlConverter();
            XmlToJsonConverter converter1 = new XmlToJsonConverter();
            converter.convert("jsontoxml.json", "jsontoxml.xml");
            converter1.convert("jsontoxml.xml", "jsontoxml.json");

            Assert.Equal(@"{""root"":{""field1"":""b"",""field2"":""33"",""field3"":""-22.5"",""field4"":""false""}}", TestUtils.ReadFile("jsontoxml.json").Replace("\r\n", "").Replace("  ", ""));
        }
    }
}