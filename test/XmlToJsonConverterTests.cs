using System;
using Xunit;
using project;
using System.IO;

namespace test
{
    public class XmlToJsonConverterTests {

        [Fact]
        public void testDataTypes() {
            TestUtils.WriteFile("xmltojson.xml", @"<root><field1>b</field1><field2>33</field2><field3>-22.5</field3><field4>false</field4></root>");

            XmlToJsonConverter converter = new XmlToJsonConverter();
            converter.convert("xmltojson.xml", "xmltojson.json");

            Assert.Equal(@"{""root"":{""field1"":""b"",""field2"":""33"",""field3"":""-22.5"",""field4"":""false""}}", TestUtils.ReadFile("xmltojson.json").Replace("\r\n", "").Replace("  ", ""));
        }

        [Fact]
        public void testEmpty() {
            TestUtils.WriteFile("xmltojson.xml", @"<root />");

            XmlToJsonConverter converter = new XmlToJsonConverter();
            converter.convert("xmltojson.xml", "xmltojson.json");

            Assert.Equal(@"{""root"":null}", TestUtils.ReadFile("xmltojson.json").Replace("\r\n", "").Replace("  ", ""));
        }

        [Fact]
        public void testCycleConvertation() {
            TestUtils.WriteFile("xmltojson.xml", @"<root><field1>b</field1><field2>33</field2><field3>-22.5</field3><field4>false</field4></root>");

            JsonToXmlConverter converter = new JsonToXmlConverter();
            XmlToJsonConverter converter1 = new XmlToJsonConverter();
            converter1.convert("xmltojson.xml", "xmltojson.json");
            converter.convert("xmltojson.json", "xmltojson.xml");

            Assert.Equal(@"<root><field1>b</field1><field2>33</field2><field3>-22.5</field3><field4>false</field4></root>", TestUtils.ReadFile("xmltojson.xml").Replace("\r\n", "").Replace("  ", ""));
        }
    }
}