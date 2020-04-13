using System;

namespace project {

    public static class CLIHandler {
        public static void showHelp() {
            Console.WriteLine(@"Possible options (order of arguments is important):
            --convert-file --from <json|xml> --to <xml|json> --source <filepath> --target <filepath>
            --convert-string --from <json|xml> --to <xml|json> <string>
            --help - show this message");
        }

        public static void handleStringConversion(string[] args) {
            if (args.Length < 6) {
                Console.WriteLine("Not enough arguments");
                return;
            }

            if (args[1] == "--from" && args[3] == "--to") {
                if (args[2] == "json" && args[4] == "xml") {
                    JsonToXmlConverter converter = new JsonToXmlConverter();
                    Console.WriteLine(converter.convert(args[5]));
                }
                else if (args[2] == "xml" && args[4] == "json") {
                    XmlToJsonConverter converter = new XmlToJsonConverter();
                    Console.WriteLine(converter.convert(args[5]));
                }
                else {
                    Console.WriteLine("Invalid conversion formats");
                }
            }
            else {
                Console.WriteLine("Cannot identify 'from' and 'to' parameters");
            }
        }

        public static void handleFileConversion(string[] args) {

        }
    }

}