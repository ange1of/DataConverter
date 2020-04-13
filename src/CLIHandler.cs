using System;

namespace project {

    public static class CLIHandler {
        public static void showHelp() {
            Console.WriteLine(@"Possible options (order of arguments is important):
    --convert-file --from <json|xml> --to <xml|json> --source <filepath> --target <filepath>
    --convert-string --from <json|xml> --to <xml|json> <string>
    --validate --type <xml|json> <string>
    --help");
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
            if (args.Length < 9) {
                Console.WriteLine("Not enough arguments");
                return;
            }

            if (args[1] == "--from" && args[3] == "--to" && args[5] == "--source" && args[7] == "--target") {
                if (args[2] == "json" && args[4] == "xml") {
                    JsonToXmlConverter converter = new JsonToXmlConverter();
                    converter.convert(args[6], args[8]);
                }
                else if (args[2] == "xml" && args[4] == "json") {
                    XmlToJsonConverter converter = new XmlToJsonConverter();
                    converter.convert(args[6], args[8]);
                }
                else {
                    Console.WriteLine("Invalid conversion formats");
                }
            }
            else {
                Console.WriteLine("Wrong arguments fromat");
            }
        }

        public static void handleValidation(string[] args) {
            if (args.Length < 4) {
                Console.WriteLine("Not enough arguments");
                return;
            }

            if (args[1] == "type") {
                if (args[2] == "json") {
                    JsonValidator validator = new JsonValidator();
                    Console.WriteLine(validator.validate(args[3]));
                }
                else if (args[2] == "xml") {
                    XmlValidator validator = new XmlValidator();
                    Console.WriteLine(validator.validate(args[3]));
                }
                else {
                    Console.WriteLine("Invalid validation format");
                }
            }
            else {
                Console.WriteLine("Cannot identify 'type' parameter");
            }
        }
    }

}