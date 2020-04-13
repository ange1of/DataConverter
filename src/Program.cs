using System;

namespace project
{
    class Program
    {
        static void Main(string[] args) {
            if (args.Length < 1) {
                Console.WriteLine("Not enough arguments");
                return;
            }

            switch (args[0]) {
                case "--help":
                    CLIHandler.showHelp();
                    break;
                case "--convert-string":
                    CLIHandler.handleStringConversion(args);
                    break;
                case "--convert-file":
                    CLIHandler.handleFileConversion(args);
                    break;
                case "--validate":
                    CLIHandler.handleValidation(args);
                    break;
                default:
                    Console.WriteLine("Unknown arguments format");
                    break;
            }

        }
    }
}
