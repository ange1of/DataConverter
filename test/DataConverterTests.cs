using System;
using Xunit;
using project;
using System.IO;

namespace test
{
    public class DataConverterTests
    {
        [Fact]
        public void testJsonDumpDataTypes() {
            var testObject = new { field1 = "b", field2 = 33, field3 = -22.5, field4 = false };
            DataConverter.dumpObjectToJsonFile(testObject, "testFile.json");

            Assert.Equal("{\"field1\":\"b\",\"field2\":33,\"field3\":-22.5,\"field4\":false}", TestUtils.ReadFile("testFile.json"));
        }

        [Fact]
        public void testJsonDumpEmpty() {
            var testObject = new {};
            DataConverter.dumpObjectToJsonFile(testObject, "testFile.json");

            Assert.Equal("{}", TestUtils.ReadFile("testFile.json"));
        }

        [Fact]
        public void testJsonDumpNull() {
            Object testObject = null;
            DataConverter.dumpObjectToJsonFile(testObject, "testFile.json");

            Assert.Equal("null", TestUtils.ReadFile("testFile.json"));
        }

        [Fact]
        public void testJsonDumpArray() {
            var testObject = new {field1 = new int[] {1,2,3}};
            DataConverter.dumpObjectToJsonFile(testObject, "testFile.json");

            Assert.Equal("{\"field1\":[1,2,3]}", TestUtils.ReadFile("testFile.json"));
        }

        [Fact]
        public void testJsonDumpNested() {
            var testObject = new {field1 = new {field1 = 1}};
            DataConverter.dumpObjectToJsonFile(testObject, "testFile.json");

            Assert.Equal("{\"field1\":{\"field1\":1}}", TestUtils.ReadFile("testFile.json"));
        }

        [Fact]
        public void testJsonDumpNewFolder() {
            var testObject = new {};
            DataConverter.dumpObjectToJsonFile(testObject, "testFolder/testFile.json");

            Assert.Equal("{}", TestUtils.ReadFile(Path.GetFullPath("testFolder/testFile.json")));
        }

        [Fact]
        public void testXmlDumpDataTypes() {
            var testObject = new TestClass();
            DataConverter.dumpObjectToXmlFile(testObject, "testFile.xml");

            string expected = @"<?xml version=""1.0"" encoding=""utf-8""?><TestClass xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema""><a>1</a><b>-22.5</b><c>false</c><d>a</d><e><int>1</int><int>2</int><int>3</int><int>4</int></e></TestClass>";

            Assert.Equal(expected, TestUtils.ReadFile("testFile.xml").Replace("\r\n", "").Replace("  ", ""));
        }

        [Fact]
        public void testXmlDumpEmpty() {
            var testObject = new TestClassEmpty();
            DataConverter.dumpObjectToXmlFile(testObject, "testFile.xml");

            string expected = @"<?xml version=""1.0"" encoding=""utf-8""?><TestClassEmpty xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" />";

            Assert.Equal(expected, TestUtils.ReadFile("testFile.xml").Replace("\r\n", "").Replace("  ", ""));
        }

        [Fact]
        public void testXmlDumpNewFolder() {
            var testObject = new TestClassEmpty();
            DataConverter.dumpObjectToXmlFile(testObject, "testFolder2/testFile.xml");

            string expected = @"<?xml version=""1.0"" encoding=""utf-8""?><TestClassEmpty xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" />";

            Assert.Equal(expected, TestUtils.ReadFile("testFolder2/testFile.xml").Replace("\r\n", "").Replace("  ", ""));
        }

        public class TestClass {
            public int a = 1;
            public double b = -22.5;
            public bool c = false;
            public string d = "a";
            public int[] e = {1,2,3,4};
            public Object f = null;
        }

        public class TestClassEmpty {}
    }
}
