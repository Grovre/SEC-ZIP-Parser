using System;
using SEC_ZIP_Parser.Classes;
using SEC_ZIP_Parser.Classes.Json;
using SEC_ZIP_Parser.Classes.Json.Files;

namespace SEC_ZIP_Parser
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            const string dir = "C:\\Users\\Landon\\Downloads\\submissions";
            var files = new SubmissionFiles(dir);
            var enumerator = files.FilePaths;
            foreach (var path in enumerator)
            {
                var parser = new CompanyJsonParser(path);
                var co = parser.Parse();
                Console.WriteLine(co.AsString());
            }
        }
    }
}