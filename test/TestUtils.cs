using System.IO;

namespace test {
    static class TestUtils {
        public static string ReadFile(string filePath) {
            using (StreamReader sr = new StreamReader(filePath)) {
                return sr.ReadToEnd();
            }
        }

        public static void WriteFile(string filePath, string content) {
            using (StreamWriter sr = new StreamWriter(filePath)) {
                sr.Write(content);
            }
        }
    }
}