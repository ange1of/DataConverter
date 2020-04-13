using System;
using Xunit;
using project;
using System.IO;

namespace test {

    public class ValidatorsTests {
        [Fact]
        public void testEmptyJson() {
            JsonValidator val = new JsonValidator();
            Assert.Equal(true, val.validate(""));
        }

        [Fact]
        public void testEmptyXml() {
            XmlValidator val = new XmlValidator();
            Assert.Equal(true, val.validate(""));
        }

        [Fact]
        public void testSimpleJson() {
            JsonValidator val = new JsonValidator();
            Assert.Equal(true, val.validate(@"{""root"":{ ""field1"":""b"", ""field2"" : 33, ""field3"" : -22.5, ""field4"" : false }}"));
        }

        [Fact]
        public void testSimpleXml() {
            XmlValidator val = new XmlValidator();
            Assert.Equal(true, val.validate(@"<root><field1>b</field1><field2>33</field2><field3>-22.5</field3><field4>false</field4></root>"));
        }
    }

}